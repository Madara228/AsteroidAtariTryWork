using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private Vector3 spawnPosition;

    public static Spawner Instance;

    [SerializeField]
    private int currentCount = 30;

    private IEnumerator Start()
    {
        if (Instance == null)
            Instance = this;
        yield return new WaitForEndOfFrame();
        SpawnWave();
    }
    
    public void SpawnWave()
    {
        for (int i = 0; i < currentCount; i++)
        {
            SpawnObject(ObjectPooler.ObjectInfo.ObjectType.Enemy1, new Vector3(Random.Range(-7.5f, 7.5f),
                Random.Range(-5, 5)), Quaternion.identity);
        }
    }

    public void SpawnObject(ObjectPooler.ObjectInfo.ObjectType type,Vector3 position, Quaternion rotation)
    {
        var aster = ObjectPooler.Instance.GetObject(type);
        aster.GetComponent<IPoolledObject>().OnCreate(position, rotation);
    }

}
