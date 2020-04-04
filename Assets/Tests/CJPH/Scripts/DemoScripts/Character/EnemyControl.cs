using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float enemyMaxHP;                    //敌人最大HP
    public float enemyHP;                       //敌人当前HP
    public Animator enemyAnimator;              //敌人角色动画机
    public List<AAttackMode> enemyAttackModes;  //敌人攻击模块
    public AMoveMode enemyMoveMode;             //敌人移动模块
    public AHitMode enemyHitMode;               //敌人受伤模块
    public float enemySize;                     //敌人判定大小（暂时没用，使用的圆形碰撞体）
    public float enemyAttackPoint;              //敌人攻击力
    public float enemyDefensePoint;             //敌人防御力
    [HideInInspector]
    public bool isDead;                         //敌人角色是否死亡
    public float hatredRange;                   //仇恨距离
    public List<GameObject> itemDropped;        //掉落物品
    [Range(0,1)]
    public List<float> droppedRate;             //掉落率
    public List<ABuff> buffList;                //所有BUFF的列表

    // Use this for initialization
    void Awake()
    {
        buffList = new List<ABuff>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < buffList.Count; i++)
        {
            buffList[i].OnBuffUpdate();
        }
        IsAlive();
        for (int i = 0; i < enemyAttackModes.Count; i++)
        {
            enemyAttackModes[i].AttackButtonDown();
        }
        enemyMoveMode.Move();
        enemyHitMode.Hit();
    }
    void IsAlive()
    {
        if (enemyHP <= 0)
        {
            isDead = true;
            enemyAnimator.SetBool("isDied", true);
            GetComponent<CircleCollider2D>().enabled = false;
        }
        if (isDead)
        {
            AnimatorStateInfo playerAniInfo = enemyAnimator.GetCurrentAnimatorStateInfo(0);
            if (playerAniInfo.IsName("Die") && playerAniInfo.normalizedTime > 1.0f)
            {
                DemoSceneManager.Instance.enemies.Remove(gameObject);
                for (int i = 0; i < droppedRate.Count; i++)
                {
                    if (Random.value <= droppedRate[i])
                    {
                        Instantiate(itemDropped[i],transform.position,Quaternion.identity);
                    }
                }
                Destroy(gameObject);
            }
        }
    }

    //添加BUFF
    public void AddBuff(ABuff buff)
    {
        buffList.Add(buff);
        buff.OnBuffAdd();
    }
    //移除BUFF
    public void RemoveBuff(ABuff buff)
    {
        if (buffList.Contains(buff))
        {
            buffList.Remove(buff);
            buff.OnBuffRemove();
        }
    }

    public void SetAttackMode(AAttackMode attackMode, int index)
    {
        enemyAttackModes[index] = attackMode;
    }

    public void SetMoveMode(AMoveMode moveMode)
    {
        enemyMoveMode = moveMode;
    }

    public void SetHitMode(AHitMode hitMode)
    {
        enemyHitMode = hitMode;
    }
}
