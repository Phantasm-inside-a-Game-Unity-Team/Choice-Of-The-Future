using UnityEngine;
using System.Collections;

public abstract class AAttackMode : MonoBehaviour
{
    [HideInInspector]
    public bool isCannotAttack;
    public int attackModeIndex;                 //攻击模式的编号
    public string attackModeName;               //攻击模式的名字
    public abstract void AttackButtonDown();    //攻击键按下时的操作
    public abstract void AttackButtonUp();      //攻击键未按下时的操作
    public abstract void PowerUp(int power);    //增加攻击力
}
