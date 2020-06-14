﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Bullent_Bat_01 : ABullent
{
    public float velocity;              //弹幕速度(近战弹幕为零)
    public float acceleration;          //弹幕加速度(近战弹幕为零)
    public float angularVelocity;       //弹幕角速度（近战武器砍人效果，回旋镖回旋效果）
    public Vector3 rotationCenter;      //旋转中心
    public float bullentSize;           //攻击判定半径
    public GameObject hitEffect;        //命中特效

    Vector3 direction;                  //实际速度方向
    float startTime;                    //弹幕产生的时间点
    //public List<GameObject> enemies;    //场景中敌人列表
    public int effect;                  //攻击效果

    public List<ABuff> buffList;        //弹幕上所有会触发的buff效果列表
    public BuffType thisBuffType;       //弹幕初始自带的buff类型
    public List<float> thisBuffPara;    //弹幕初始自带的buff参数

    void Awake()
    {
        buffList = new List<ABuff>();
    }

    // Use this for initialization
    void OnEnable()
    {
        startTime = Time.timeSinceLevelLoad;
        direction = transform.up;
        GetComponent<CircleCollider2D>().radius = bullentSize;
        buffList.Clear();
        //enemies = DemoSceneManager.Instance.enemies;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.timeSinceLevelLoad - startTime) > life)
        {
            ObjectPoolManager.Instance.PutObject(gameObject);
        }
        //CollisionDet();
        //transform.Translate(direction * Time.deltaTime, Space.World);
        BullentTranslate();
    }

    //void CollisionDet()
    //{
    //    for (int index = 0; index < enemies.Count; index++)
    //    {
    //        if ((transform.position - new Vector3(0, 0, transform.position.z) - enemies[index].transform.position).magnitude < (bullentSize + enemies[index].GetComponent<EnemyControl>().enemySize) && enemies[index].GetComponent<EnemyControl>().isDead == false)
    //        {
    //            if (enemies[index].GetComponent<EnemyControl>().enemyHitMode != null)
    //            {
    //                enemies[index].GetComponent<EnemyControl>().enemyHitMode.BeHit(attackPoint, effect);
    //                Instantiate(hitEffect, transform.position, Quaternion.identity);
    //                Destroy(gameObject);
    //            }
    //            else
    //                Debug.Log("Enemy is not found");
    //        }
    //    }
    //}

    void BullentTranslate()
    {
        transform.RotateAround(transform.position + Quaternion.AngleAxis(transform.eulerAngles.z, Vector3.forward) * rotationCenter, Vector3.forward, angularVelocity * Time.deltaTime);
        velocity += acceleration;
        transform.Translate(velocity * Time.deltaTime * direction, Space.World);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 10)
        {
            PlayerControl playerControl = collider.gameObject.GetComponentInParent<PlayerControl>();
            buffList.Add(BuffGroup.CreateBuff(playerControl, thisBuffType, thisBuffPara));  //将弹幕初始自带的buff加到整个buff列表中
            foreach (ABuff buff in buffList)    //将所有buff加到角色上
            {
                playerControl.AddBuff(buff);
            }
            playerControl.playerHitMode.BeHit(attackPoint, buffList, effect);
        }
        ObjectPoolManager.Instance.PutObject(gameObject);
    }
}
