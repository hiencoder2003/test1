using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool _instance;
    public static ObjectPool Instance
    { get
        {
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<ObjectPool>();
            }
            return _instance;
        }
    }
    private List<GameObject> _poollist = new List<GameObject>();
    private Stack<GameObject> _poolList = new Stack<GameObject>();
    private Queue<GameObject> _poolQueue = new Queue<GameObject>();

    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize = 10;

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            var obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            obj.name = prefab.name + $" ({i}";
            _poolQueue.Enqueue(obj);
        }
    }
    public bool CanSpawn()
    {
        return _poolQueue.Count > 0;
    }
    public GameObject PickOne(Transform parent)
    {
        var obj = _poolQueue.Dequeue();
        obj.transform.SetParent(parent);
        return obj;
    }

    public void ReturnOne(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(transform);
        _poolQueue.Enqueue(obj );
    }

    
}
