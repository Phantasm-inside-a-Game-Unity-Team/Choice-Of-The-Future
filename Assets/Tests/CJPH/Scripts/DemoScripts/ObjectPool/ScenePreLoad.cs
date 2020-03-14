using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePreLoad : MonoBehaviour
{
    public List<PreLoadObject> preLoadList;
    // Start is called before the first frame update
    void Start()
    {
        foreach (PreLoadObject plo in preLoadList)
        {
            ObjectPoolManager.Instance.Preload(plo.preLoadObj, plo.preLoadCount, plo.maxCount);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class PreLoadObject
{
    public GameObject preLoadObj;
    public int preLoadCount;
    public int maxCount;
}
