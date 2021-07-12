using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolledObject
{
    ObjectPooler.ObjectInfo.ObjectType Type { get; }
    
}
