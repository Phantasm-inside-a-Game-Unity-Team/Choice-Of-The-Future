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
    public float bullentSize;           //攻击判定半径
    public GameObject hitEffect;        //命中特效

    Vector3 direction;                  //实际速度方向
    float startTime;                    //弹幕产生的时间点
    //public List<GameObject> enemies;    //场景中敌人列表(暂未使用)
    public int effect;                  //攻击效果
    public Animator bullentAnimator;    //爆炸动画机
    float timeSinceLaunch;              //子弹发射后计时
    Vector3 startPosition;              //子弹发射位置
    float a;                            //抛物线方程二次项系数
    float x;                            //抛物线方程自变量x
    float y;                            //抛物线方程应变量y
    float explodeStartTime;             //爆炸开始时间
    List<Collider2D> hitEnemies=new List<Collider2D>();        //已经命中的敌人，为了只进行一次攻击判定

    // Use this for initialization
    void OnEnable()
    {
        startPosition = transform.position;
        a = -4 * hight * velocity * velocity / distance / distance;
        explodeStartTime = distance / velocity;
        startTime = Time.timeSinceLevelLoad;
        Debug.Log(startTime);
        Debug.Log(startPosition);
        direction = transform.up;
        GetComponent<CircleCollider2D>().radius = bullentSize;
        //enemies = DemoSceneManager.Instance.enemies;
    }

    // Update is called once per frame
    void Update()
    {

        //if ((Time.timeSinceLevelLoad - startTime) > life)
        //{
        //    if ((Time.timeSinceLevelLoad - startTime) > (life + 0.1))
        //    {
        //        Destroy(gameObject);
        //    }
        //    return;
        //}
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
        timeSinceLaunch = Time.time - startTime;
        //抛物线计算方式见https://blog.csdn.net/somnusand/article/details/88630490
        if (timeSinceLaunch < explodeStartTime)
        {
            x = timeSinceLaunch * velocity;
            y = a * timeSinceLaunch * timeSinceLaunch - a * (distance / velocity) * timeSinceLaunch;
            transform.position = direction.normalized * x + Vector3.up * y + startPosition; //抛物线弹幕显示位置

            transform.RotateAround(transform.position + Quaternion.AngleAxis(transform.eulerAngles.z, Vector3.forward) * rotationCenter, Vector3.forward, angularVelocity * Time.deltaTime);
            velocity += acceleration;
            //transform.Translate(velocity * Time.deltaTime * direction, Space.World);
        }
        else
        {
            bullentAnimator.SetBool("isExploded", true);
            //子弹判定从0.16变大到0.4，用时0.1秒
            GetComponent<CircleCollider2D>().radius = Mathf.Lerp(0.16f, 0.4f, (timeSinceLaunch - explodeStartTime) / 0.1f);
            AnimatorStateInfo playerAniInfo = bullentAnimator.GetCurrentAnimatorStateInfo(0);
            if (playerAniInfo.IsName("Explode") && playerAniInfo.normalizedTime > 1)
            {
                bullentAnimator.SetBool("isExploded", false);
                ObjectPool.Instance.PutObject(gameObject);
            }
        }
    }

    //爆炸子弹需要使用Stay方法
    void OnTriggerStay2D(Collider2D collider)
    {
        if (timeSinceLaunch > explodeStartTime)
        {
            if (collider.gameObject.layer == 8)
            {
                if (hitEnemies==null||!hitEnemies.Contains(collider))
                {
                    collider.gameObject.GetComponent<EnemyControl>().enemyHitMode.BeHit(attackPoint, effect);
                    hitEnemies.Add(collider);
                }
            }
        }
    }
}
