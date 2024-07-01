using System.Collections;
using System.Collections.Generic;
using Mirror;
using Unity.Mathematics;
using UnityEngine;

public class RaceNetworkManager : NetworkManager
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private SpawnObstacle spawnObstacle;
    [SerializeField] private float spawnThreshold = 3f;
    [SerializeField] private float countTime = 0;
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        //base.OnServerAddPlayer(conn);
        Vector3 spawnPoint = spawnPoints[numPlayers].position;

        var player = 
            Instantiate(playerPrefab, spawnPoint, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player);

    }
    private void FixedUpdate()
    {
        countTime += Time.fixedDeltaTime;
        if (countTime >= spawnThreshold)
        {
            countTime -= spawnThreshold;
            SpawnObstacle.Spawn();
        }
    }
}
