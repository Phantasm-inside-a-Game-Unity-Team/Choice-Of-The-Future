using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public List<AAttackMode> enemyAttackModes;  //玩家攻击模块
    public AMoveMode enemyMoveMode;             //敌人移动模块
    public AHitMode enemyHitMode;               //敌人受伤模块
    public float enemySize;                     //敌人判定大小
    public int enemyHP;                         //敌人HP
    public bool isDead;                         //敌人角色是否死亡
    public float hatredRange;                   //仇恨距离

    // Use this for initialization
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemyAttackModes.Count; i++)
        {
            enemyAttackModes[i].AttackButtonDown();
        }
        enemyMoveMode.Move();
        enemyHitMode.Hit();
    }
    void IsAlive()
    {

    }
    public void SetAttackMode(AAttackMode attackMode,int index)
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
