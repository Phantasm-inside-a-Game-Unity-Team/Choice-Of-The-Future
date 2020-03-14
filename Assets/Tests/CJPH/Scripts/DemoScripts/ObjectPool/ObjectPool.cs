using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPool
{
    public string name;
    public Queue<GameObject> pool = new Queue<GameObject>();
    public int maxCount;
    public int number
    {
        get
        {
            return pool.Count;
        }
    }

    public ObjectPool(string name,int maxCount)
    {
        this.name = name;
        this.maxCount = maxCount;
    }
}
