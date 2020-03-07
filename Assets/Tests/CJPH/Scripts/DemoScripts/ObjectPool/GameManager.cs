﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class GameManager : SingletonTemplate<GameManager> 
{

    public GameObject testObject;
    // Start is called before the first frame update
    void Start()
    {
        //预热
        ObjectPool.Instance.Preload(testObject, 500);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TestOfNotOP();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            TestOfOP();
        }

    }

    //无对象池测试
    public void TestOfNotOP()
    {
        StartCoroutine(CreateOfNotOP());
    }


    private IEnumerator CreateOfNotOP()
    {
        //统计500帧所用时间
        float t = 0.0f;
        //每一帧生成一个对象，定时2秒后自动消除
        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                int x = Random.Range(-30, 30);
                int y = Random.Range(-30, 30);
                int z = Random.Range(-30, 30);
                GameObject newObject = Instantiate(testObject, new Vector3(x, y, z), Quaternion.identity);
                Destroy(newObject, 2.0f);
            }
            yield return null;
            t += Time.deltaTime;
        }
        Debug.Log("无对象池50帧使用秒数:" + t);
    }

    //使用对象池测试
    public void TestOfOP()
    {

        StartCoroutine(CreateOfOP());
    }

    private IEnumerator CreateOfOP()
    {
        //统计500帧所用时间
        float t = 0.0f;
        //每一帧生成一个对象，定时2秒后自动消除
        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                int x = Random.Range(-30, 30);
                int y = Random.Range(-30, 30);
                int z = Random.Range(-30, 30);
                GameObject newObject = ObjectPool.Instance.GetObject(testObject, new Vector3(x, y, z), Quaternion.identity);
                ObjectPool.Instance.PutObject(newObject);
            }
            yield return null;
            t += Time.deltaTime;
        }
        Debug.Log("使用对象池50帧使用秒数:" + t);
    }
}