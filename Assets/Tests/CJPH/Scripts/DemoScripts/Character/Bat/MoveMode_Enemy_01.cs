using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMode_Enemy_01 : AMoveMode
{
    public EnemyControl enemyControl;       //角色控制器
    public Animator enemyAnimator;          //角色动画机
    public Rigidbody2D rb;                  //角色刚体
    public float moveTime;                  //移动时间
    public float moveInterval;              //移动间隔时间
    GameObject player;                      //玩家角色
    Vector2 enemyDirection;                 //角色朝向
    float timeCount;                        //移动计时
    bool isMoving;

    void Start()
    {
        enemyDirection.Set(0, -1);  //角色默认朝下
        player = DemoSceneManager.Instance.player;
    }

    public override void Move()
    {
        if (isCannontMove)
            return;
        if ((player.transform.position - transform.position).magnitude < enemyControl.hatredRange)
        {
            rb.velocity = Vector2.zero;
            enemyDirection = player.transform.position - transform.position;
            enemyAnimator.SetFloat("moveX", enemyDirection.x);
            enemyAnimator.SetFloat("moveY", enemyDirection.y);
            timeCount = 0;
            isMoving = false;
        }
        else
        {
            timeCount += Time.deltaTime;
            if (timeCount > moveInterval && timeCount < moveInterval + moveTime)
            {
                if (!isMoving)
                {
                    enemyDirection = Random.insideUnitCircle.normalized;
                    enemyAnimator.SetFloat("moveX", enemyDirection.x);
                    enemyAnimator.SetFloat("moveY", enemyDirection.y);
                    isMoving = true;
                }
                else
                {
                    rb.velocity = enemyDirection * moveSpeed;
                }
            }
            else if (timeCount > moveInterval + moveTime)
            {
                isMoving = false;
                timeCount = 0;
                rb.velocity = Vector2.zero;
            }
        }
    }

    public override void IsDelayed()
    {

    }
}
