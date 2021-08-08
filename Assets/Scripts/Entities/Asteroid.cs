using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Asteroid : MonoBehaviour, IPoolledObject
{
    public ObjectPooler.ObjectInfo.ObjectType Type => type;

    [SerializeField]
    private ObjectPooler.ObjectInfo.ObjectType type;
    public float maxThrust;
    public float maxTorque;
    public Rigidbody2D rb;
    public int asteroidPoint;
    public void OnCreate(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);
        rb.AddForce(thrust);
        rb.AddTorque(torque);
    }
   

    public void OnPoolDestroy()
    {

    }
}
