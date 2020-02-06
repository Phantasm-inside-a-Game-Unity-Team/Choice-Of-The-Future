using UnityEngine;
using System.Collections;

public abstract class SingletonTemplate<T> : MonoBehaviour where T : MonoBehaviour
{
    private static volatile T instance;
    private static object syncRoot = new Object();
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        T[] instances = FindObjectsOfType<T>();
                        if (instances.Length != 0)
                        {
                            instance = instances[0];
                            for (var i = 1; i < instances.Length; i++)
                            {
                                Destroy(instances[i].gameObject);
                            }
                        }
                        else
                        {
                            GameObject go = new GameObject();
                            go.name = typeof(T).Name;
                            instance = go.AddComponent<T>();
                            DontDestroyOnLoad(go);
                        }
                    }
                }
            }
            return instance;
        }
    }
}
