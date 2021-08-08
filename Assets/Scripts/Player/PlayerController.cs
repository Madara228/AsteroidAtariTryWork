using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private ObjectPooler instance;
    private Camera cam;
    private Rigidbody2D rb;
    
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        if (Input.GetMouseButtonDown(0))
        {
            Spawner.Instance.SpawnObject(ObjectPooler.ObjectInfo.ObjectType.Bullet, transform.position, transform.rotation);
        }
    }
    
}
