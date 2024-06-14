using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float radius = 20f;
    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        if ( _timer > spawnInterval)
        {
            _timer -= spawnInterval;
            Spawn();
        }
    }

    private void Spawn()
    {
        if (!ObjectPool.Instance.CanSpawn()) return;
        var gameObject = ObjectPool.Instance.PickOne(transform);
        gameObject.SetActive(true);

        var pos = Random.insideUnitSphere * radius;
        pos.y = Mathf.Abs(pos.y);
        gameObject.transform.position = pos;
        gameObject.SetActive(true);
    }
    
}
