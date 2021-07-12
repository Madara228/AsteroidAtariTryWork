using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool 
{
    public Transform Container { get; set; } //Класс, хранящий в себе контейнер, чтобы спавнить объекты не в корнее иерархии а в дочерних контейнерах
    public Queue<GameObject> Objects;

    public Pool(Transform container)
    {
        Container = container;
        Objects = new Queue<GameObject>(); //Используем очередь, т.к. когда мы берем объект из очереди - он автоматически удаляется из неё
    }
}
