using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolledObject
{
    public ObjectPooler.ObjectInfo.ObjectType Type { get; }
    private Vector3 collidedPosition;
    private float lifetime = 3f;
    private float currentLifeTime;
    private float speed = 10f;
    void Update()
    {
        transform.position += transform.up*Time.deltaTime *speed;
    }
    public void OnCreate(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
        currentLifeTime = lifetime;
        collidedPosition = new Vector3(0, 0, 0);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<IPoolledObject>()!=null)
        {
            collidedPosition = other.gameObject.transform.position;
            var t = other.gameObject.GetComponent<Asteroid>();
            ScoreController.Instance.AddScore(t.asteroidPoint);
            ObjectPooler.Instance.DestroyObject(other.gameObject);
            if (Enum.IsDefined(typeof(ObjectPooler.ObjectInfo.ObjectType),((int)t.Type)+1))
            {
                Spawner.Instance.SpawnObject(t.Type+1, collidedPosition, Quaternion.identity);
                Spawner.Instance.SpawnObject(t.Type+1, collidedPosition, Quaternion.identity);
            }
            OnPoolDestroy();
        }
    }

    public void OnPoolDestroy()
    {
        ObjectPooler.Instance.DestroyObject(this.gameObject);
    }
}
