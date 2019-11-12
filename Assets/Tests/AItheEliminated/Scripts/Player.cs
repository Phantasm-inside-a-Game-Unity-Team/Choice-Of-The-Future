using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    /*
     *该类为玩家角色的类 
     * 
     * 属性当中有HUD当中反映的，也有不显示在HUD上的。
     * 此处修改相应值的函数，在此处同时修改HUD的反映值
     */
    //总残机数
    //另外，残机的机制为：每个残机单独当做一个血条计算，每次扣血不会超过一个残机，如果超过一个残机，则该残机消失，接着使用下一个残机。
    public int lifeCounts;
    //当前残机数
    public int lifeCounts_Current;
    //当前残机最大血量
    public float lifePointValue;
    //当前残机当前血量
    public float lifePointValue_Current;
    //总P点数
    public float power;
    //当前P点数
    public float power_Current;
    //总蓝点数
    public float point;
    //当前蓝点数
    public float point_Current;


    //最基本的Getter和Setter
    public int GetLifeCounts()
    {
        return lifeCounts_Current;
    }
    public float GetCurrentLifeValue()
    {
        return lifePointValue_Current;
    }
    public float GetPoint()
    {
        return point_Current;
    }
    public float GetPower()
    {
        return power_Current;
    }
}
