using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullent_Sakuya_03 : ABullent
{
    public float distance;              //子弹落地距离
    public float hight;                 //子弹抛物线高度
    public float velocity;              //弹幕速度(近战弹幕为零)
    public float acceleration;          //弹幕加速度(近战弹幕为零)
    public float angularVelocity;       //弹幕角速度（近战武器砍人效果，回旋镖回旋效果）
    public Vector3 rotationCenter;      //旋转中心
    public int attackPoint;             //弹幕攻击力
    public float bullentSize;           //攻击判定半径
    public GameObject hitEffect;        //命中特效

    Vector3 direction;                  //实际速度方向
    float startTime;                    //弹幕产生的时间点
    public List<GameObject> enemies;    //场景中敌人列表
    public int effect;                  //攻击效果
    float deltaTime;
    Vector3 startPosition;
    float a;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        a = -4 * hight * velocity * velocity / distance / distance;
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
            if ((Time.timeSinceLevelLoad - startTime) > (life + 0.1))
            {
                Destroy(gameObject);
            }
            return;
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
        //抛物线计算方式见https://blog.csdn.net/somnusand/article/details/88630490
        deltaTime += Time.deltaTime;
        float x = deltaTime * velocity;
        float y = a * deltaTime * deltaTime - a * (distance / velocity) * deltaTime;
        if (y < 0)
        {
            Destroy(gameObject);
        }
        transform.position = direction.normalized * x + Vector3.up * y + startPosition;
        transform.RotateAround(transform.position + Quaternion.AngleAxis(transform.eulerAngles.z, Vector3.forward) * rotationCenter, Vector3.forward, angularVelocity * Time.deltaTime);
        velocity += acceleration;
        //transform.Translate(velocity * Time.deltaTime * direction, Space.World);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 8)
        {
            collider.gameObject.GetComponent<EnemyControl>().enemyHitMode.BeHit(attackPoint, effect);
            Destroy(gameObject);
        }
    }
}
