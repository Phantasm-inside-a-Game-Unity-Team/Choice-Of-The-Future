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
    float timeCount;                        //移动计时
    bool isMoving;                          //角色是否移动中

    void Start()
    {
        SetDirection(Vector2.down);  //角色默认朝下
    }

    public override void Move()
    {
        if (isCannontMove || enemyControl.isDead)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        player = DemoSceneManager.Instance.mainPlayer;
        if ((player.transform.position - transform.position).magnitude < enemyControl.hatredRange)
        {
            rb.velocity = Vector2.zero;
            characterDirection = player.transform.position - transform.position;
            enemyAnimator.SetFloat("moveX", characterDirection.x);
            enemyAnimator.SetFloat("moveY", characterDirection.y);
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
                    characterDirection = Random.insideUnitCircle.normalized;
                    enemyAnimator.SetFloat("moveX", characterDirection.x);
                    enemyAnimator.SetFloat("moveY", characterDirection.y);
                    isMoving = true;
                }
                else
                {
                    rb.velocity = characterDirection * moveSpeed;
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

    public override void SetDirection(Vector2 direction)
    {
        enemyAnimator.SetFloat("moveX", direction.x);
        enemyAnimator.SetFloat("moveY", direction.y);
        characterDirection = direction;
    }
}
