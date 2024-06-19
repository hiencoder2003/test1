using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PLayer : MonoBehaviour
{
    [SerializeField] private float _force = 10f;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.F))
        {
            var force1 = Vector3.forward * _force;
            var force = transform.forward * _force;
            _rb.AddForce(force, ForceMode.VelocityChange);
        }
    }
    private void OnCollisionEnter(Collision other )
    {
        if (other.gameObject.tag.Equals("obstacle"))
        {
            Return(other.gameObject);
        }
        
    }
    private void Return(GameObject obj)
    {
        ObjectPool.Instance.ReturnOne(obj);
    }
}
