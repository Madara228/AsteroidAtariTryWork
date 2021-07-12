using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour, IPoolledObject
{
    public ObjectPooler.ObjectInfo.ObjectType Type => type;

    [SerializeField]
    private ObjectPooler.ObjectInfo.ObjectType type;

    private float lifetime = 3f;
    private float currentLifeTime;
    private float speed = 10f;

    public void OnCreate(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
        currentLifeTime = lifetime;
    }

    private void Update()
    {
        // transform.Translate(Vector2.right*Time.deltaTime*10f);

        // if ((currentLifeTime -= Time.deltaTime) < 0)
        // {
        //     ObjectPooler.Instance.DestroyObject(gameObject);
        // }
    }
}
