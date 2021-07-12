using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;
    private void Awake() 
    {
        if(Instance == null)
            Instance = this;
        InitPool();
    }
    [Serializable]
    //Структура, чтобы вносит информацию через инспектор
    public struct ObjectInfo
    {
        public enum ObjectType
        {
            Enemy1,
            Enemy2
        }

        public ObjectType Type; //Тип объекта
        public GameObject Prefab; //Переменная префаба
        public int StartCount; //Начальное количество объектов в пуле
    }

    [SerializeField]
    private List<ObjectInfo> objectsInfo; //Список структур
    private Dictionary<ObjectInfo.ObjectType, Pool> pools;
    
    private GameObject InstatiateObject(ObjectInfo.ObjectType type, Transform parent)
    {
        var go = Instantiate(objectsInfo.Find(x => x.Type == type).Prefab, parent);//Инстанс нужного объекта по типу
        go.SetActive(false);
        return go;
    }
    private void InitPool()
    {
        pools = new Dictionary<ObjectInfo.ObjectType, Pool>(); //Список контейнеров
        var emptyGO = new GameObject();
        foreach (var obj in objectsInfo)
        {
            var container = Instantiate(emptyGO, transform, false); // Создаем объект контейнера
            container.name = obj.Type.ToString(); // Переименовываем контейнеры

            pools[obj.Type] = new Pool(container.transform); //Присваеваем элементу из списка новый контейнер

            for (int i = 0; i < obj.StartCount; i++)
            {
                var go = InstatiateObject(obj.Type, container.transform); //Создаем каждый геймОбжект от каждого пула
                pools[obj.Type].Objects.Enqueue(go); //Удаляем эту парашу из очереди
            }
        }
    }

    public GameObject GetObject(ObjectInfo.ObjectType type)
    {
        var obj = pools[type].Objects.Count > 0
            ? pools[type].Objects.Dequeue() //
            : InstatiateObject(type, pools[type].Container);
        obj.SetActive(true);
        return obj;
    }

    public void DestroyObject(GameObject obj)
    {
        pools[obj.GetComponent<IPoolledObject>().Type].Objects.Enqueue(obj);
        obj.SetActive(false);
    }


    
}
