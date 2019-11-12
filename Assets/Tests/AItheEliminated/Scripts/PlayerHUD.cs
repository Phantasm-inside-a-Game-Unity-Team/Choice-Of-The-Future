using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHUD : MonoBehaviour
{
    /*该类控制玩家的HUD当中的各个元素
     * 
     * 
     */
    //残机机组
    public List<Image> LifeMarks;
    //P点条总长度
    public Image powerValue;
    //P点条当前长度
    public Image powerValue_Current;
    //P点条的阴影当前长度
    public Image powerValue_Shadow;
    //蓝点条总长度
    public Image pointValue;
    //蓝点当前长度
    public Image pointValue_Current;
    //蓝点条的阴影当前长度
    public Image pointValue_Shadow;
    //Boss条总血条
    public Image bossValue;
    //Boss当前血条
    public Image bossValue_Current;
    //Boss血条的阴影当前长度
    public Image bossValue_Shadow;
    //敌人总血条
    public Image enemyValue;
    //敌人当前血条
    public Image enemyValue_Current;
    //敌人血条的阴影当前长度
    public Image enemyValue_Shadow;



    //防止数据脏读的锁
    public static object locker = new System.Object();
    //值监视器
    public event EventHandler OnPowerChanged;
    public event EventHandler OnPointChanged;
    //
    //多个计时器
    private const float MAXIMUN_TIMER = 1f;
    private float tempTimer1;
    private float tempTimer2;
    private float tempTimer3;
    private float tempTimer4;
    void Start()
    {
        tempTimer1 = 0;
        tempTimer2 = 0;
        tempTimer3 = 0;
        tempTimer4 = 0;
        /*
        lock (locker)
        {
            //可能脏读的数据修改过程
        }
        */
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //检测各个Bar的动态变化
        BarChange();
       
    }

    //_________HUD相关方法：

    //条的量减少时施加的渐变效果
    private void BarChange()
    {
        if (powerValue_Current.fillAmount < powerValue_Shadow.fillAmount)
        {
            tempTimer1 += Time.fixedDeltaTime;
            if (tempTimer1 >= MAXIMUN_TIMER)
            {
                powerValue_Shadow.fillAmount = Mathf.Lerp(powerValue_Shadow.fillAmount, powerValue_Current.fillAmount, 0.1f);
            }
        }
        else
        {
            tempTimer1 = 0;
            powerValue_Shadow.fillAmount = powerValue_Current.fillAmount;
        }
        //////////////
        if (pointValue_Current.fillAmount < pointValue_Shadow.fillAmount)
        {
            tempTimer2 += Time.fixedDeltaTime;
            if (tempTimer2 >= MAXIMUN_TIMER)
            {
                pointValue_Shadow.fillAmount = Mathf.Lerp(pointValue_Shadow.fillAmount, pointValue_Current.fillAmount, 0.1f);
            }
        }
        else
        {
            tempTimer2 = 0;
            pointValue_Shadow.fillAmount = pointValue_Current.fillAmount;
        }
        //////////////
        if (bossValue_Current.fillAmount < bossValue_Shadow.fillAmount)
        {
            tempTimer3 += Time.fixedDeltaTime;
            if (tempTimer3>= MAXIMUN_TIMER)
            {
                bossValue_Shadow.fillAmount = Mathf.Lerp(bossValue_Shadow.fillAmount, bossValue_Current.fillAmount, 0.1f);
            }
        }
        else
        {
            tempTimer3 = 0;
            enemyValue_Shadow.fillAmount = enemyValue_Current.fillAmount;
        }
        ///////////////
        if (enemyValue_Current.fillAmount < enemyValue_Shadow.fillAmount)
        {
            tempTimer4 += Time.fixedDeltaTime;
            if (tempTimer4 >= MAXIMUN_TIMER)
            {
                enemyValue_Shadow.fillAmount = Mathf.Lerp(enemyValue_Shadow.fillAmount, enemyValue_Current.fillAmount, 0.1f);
            }
        }
        else
        {
            tempTimer4 = 0;
            enemyValue_Shadow.fillAmount = enemyValue_Current.fillAmount;
            
        }
    }

    
}
