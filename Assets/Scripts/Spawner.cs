using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private Vector3 spawnPosition;

    private int currentCount = 2;

    private IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < currentCount; i++)
        {
            SpawnAsteroid(ObjectPooler.ObjectInfo.ObjectType.Enemy1,new Vector3(Random.Range(-10f,10f),Random.Range(-5,5)),Quaternion.identity);
            Debug.Log("Created Object of Type");
        }
    }

    private void SpawnAsteroid(ObjectPooler.ObjectInfo.ObjectType type,Vector3 position, Quaternion rotation)
    {
        var aster = ObjectPooler.Instance.GetObject(type);
        aster.GetComponent<Asteroid>().OnCreate(position, rotation);
    }

}
