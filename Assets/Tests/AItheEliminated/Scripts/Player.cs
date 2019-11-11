using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /*
     *该类为玩家角色的类 
     * 
     * 属性当中有HUD当中反映的，也有不显示在HUD上的。
     * 此处修改相应值的函数，在此处同时修改HUD的反映值
     */
    //总残机数
    public int lifeCounts;
    //当前残机数
    public int lifeCounts_Current;
    //总P点数
    public float power;
    //当前P点数
    public float power_Current;
    //总蓝点数
    public float point;
    //当前蓝点数
    public float point_Current;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
