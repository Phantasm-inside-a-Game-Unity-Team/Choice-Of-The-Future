using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    // Use this for initialization
    void Start()
    {
        startTime = Time.timeSinceLevelLoad;
        direction = transform.up;
        GetComponent<CircleCollider2D>().radius = bullentSize;
        //enemies = DemoSceneManager.Instance.enemies;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.timeSinceLevelLoad - startTime) > life)
        {
            Destroy(gameObject);
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
            collider.gameObject.GetComponent<PlayerControl>().playerHitMode.BeHit(attackPoint, effect);
        }
        Destroy(gameObject);
    }
}
