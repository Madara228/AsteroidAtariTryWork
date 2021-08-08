using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolledObject
{
    ObjectPooler.ObjectInfo.ObjectType Type { get; }
    public void OnCreate(Vector3 position, Quaternion rotation);
    public void OnPoolDestroy();
}
