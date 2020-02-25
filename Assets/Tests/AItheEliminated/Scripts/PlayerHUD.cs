using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHUD : MonoBehaviour
{
    public Player playerState;
    /*该类控制玩家的HUD当中的各个元素
     * 
     * 
     */
    //残机机组
    public List<Image> LifeMarks;
    //残机机组阴影
    public List<Image> LifeMarkShadows;
    //目前残机
    public Image LifeMark;
    //目前残机阴影
    public Image LifeMarkShadow;
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
    private const float MAXTIMER = 0.2f;
    public float timer;
    private float tempTimer1;
    private float tempTimer2;
    private float tempTimer3;
    private float tempTimer4;
    void Start()
    {
        timer = 0;
        tempTimer1 = 0;
        tempTimer2 = 0;
        tempTimer3 = 0;
        tempTimer4 = 0;

        playerState = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
        GatherPlayerInfo();
        //检测各个Bar的动态变化
        BarChange();
        //残机检测
        LifeCountsChange();
        MarkShrink();
    }

    //_________HUD相关方法：

    private void GatherPlayerInfo()
    {
        float tempScale = playerState.lifePointValue_Current / (playerState.lifePointValue * 2);
        //使用playerState.lifeCounts_Current - 1避免读空
        if (LifeMarks != null)
        {
            LifeMarks[playerState.lifeCounts_Current - 1].transform.localScale = new Vector3(tempScale, tempScale, tempScale);
        }
        powerValue_Current.fillAmount = playerState.power_Current / playerState.power;
        pointValue_Current.fillAmount = playerState.pointCurrent / playerState.point;
    }
    //条的量减少时施加的渐变效果
    private void BarChange()
    {
        
        if (powerValue_Current.fillAmount < powerValue_Shadow.fillAmount)
        {//计时，渐变
            tempTimer1 += Time.fixedDeltaTime;
            if (tempTimer1 >= MAXIMUN_TIMER)
            {
                powerValue_Shadow.fillAmount = Mathf.Lerp(powerValue_Shadow.fillAmount, powerValue_Current.fillAmount, 0.1f);
            }
        }
        else
        {//阴影更短的话就直接增长到血条长度
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
    //检测残机相关
    private void LifeCountsChange()
    {
        if (LifeMarks != null)
        {
            if (LifeMarks.Count > playerState.lifeCounts_Current)
            {
                //Player里面从1开始计数，这里从0开始计数
                Debug.Log(LifeMarks.Count);
                //摧毁并移除目前的LifeMark
                Destroy(LifeMark);
                LifeMarks.Remove(LifeMark);
                Destroy(LifeMarkShadow);
                LifeMarkShadows.Remove(LifeMarkShadow);
                //换到下一个残机
                LifeMark = LifeMarks[playerState.lifeCounts_Current - 1];
                LifeMarkShadow = LifeMarkShadows[playerState.lifeCounts_Current - 1];
                Debug.Log(LifeMarks.Count);
            }
        }
        else
        {
            LifeMark = null;
        }
    }

    //管理血量变化后的阴影变化，和血条同理，延迟一秒。
    void MarkShrink()
    {
        if (LifeMark != null)
        {
            if (LifeMark.transform.localScale.x < LifeMarkShadow.transform.localScale.x)
            {
                timer += Time.fixedDeltaTime;
                if (timer >= MAXTIMER)
                {
                    timer = 0;
                    LifeMarkShadow.transform.localScale = Vector3.Lerp(LifeMarkShadow.transform.localScale, LifeMark.transform.localScale, 0.1f);
                }
            }
        }
    }
}
