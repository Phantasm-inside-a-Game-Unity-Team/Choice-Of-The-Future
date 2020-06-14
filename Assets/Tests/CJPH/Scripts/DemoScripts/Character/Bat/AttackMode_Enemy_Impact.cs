using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMode_Enemy_Impact : AAttackMode
{
    public GameObject impactCollider;       //体术攻击碰撞体
    public float colliderRadius;            //体术攻击判定半径
    public EnemyControl enemyControl;       //角色控制器
    public float attackPointRatio;          //攻击力比角色攻击力的倍数

    private GameObject colliderObject;      //实例化的体术判定碰撞体

    public override void AttackButtonDown()
    {
        if (colliderObject == null)
        {
            colliderObject = Instantiate(impactCollider, Vector3.zero, Quaternion.identity);
            colliderObject.transform.SetParent(gameObject.transform, false);
            colliderObject.GetComponent<CircleCollider2D>().radius = colliderRadius;
            colliderObject.GetComponent<ImpactAttack>().attackPoint = enemyControl.enemyAttackPoint * attackPointRatio;
        }
    }

    public override void AttackButtonUp()
    {

    }

    public override void PowerUp(int power)
    {

    }
}
