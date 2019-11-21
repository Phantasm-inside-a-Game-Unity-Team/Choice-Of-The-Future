//场景开始时用来执行MySceneManager的初始化方法
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MySceneManager.Instance.SceneStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
