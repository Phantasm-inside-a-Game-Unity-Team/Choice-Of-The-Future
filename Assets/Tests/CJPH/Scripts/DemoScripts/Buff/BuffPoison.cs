using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffPoison : ABuff
{
    private PlayerControl playerControl;
    private EnemyControl enemyControl;
    private float buffTime;             //buff持续时间
    private float minusHP;              //单次减血量
    private float effectGapTime;        //减血间隔时间
    private float timerA;               //用来对毒buff持续总时间的计时
    private float timerB;               //用来对毒单次伤害间隔时间的计时

    public BuffPoison(PlayerControl initPlayerControl, List<float> buffParaList)
    {
        playerControl = initPlayerControl;
        if (buffParaList.Count == 3)
        {
            buffTime = buffParaList[0];
            minusHP = buffParaList[1];
            effectGapTime = buffParaList[2];
        }
        else
        {
            buffTime = 5;
            minusHP = 0.5f;
            effectGapTime = 1;
        }
        buffType = BuffType.Poison;
    }
    public BuffPoison(EnemyControl initEnemyControl, List<float> buffParaList)
    {
        enemyControl = initEnemyControl;
        if (buffParaList.Count == 3)
        {
            buffTime = buffParaList[0];
            minusHP = buffParaList[1];
            effectGapTime = buffParaList[2];
        }
        else
        {
            buffTime = 5;
            minusHP = 0.5f;
            effectGapTime = 1;
        }
        buffType = BuffType.Poison;
    }

    public override void OnBuffAdd()
    {
        if (playerControl != null)
        {
            BuffPoison buffPoison = (BuffPoison)playerControl.buffList.Find((ABuff buff) => buff.buffType == BuffType.Poison);
            if (buffPoison == null)
            {
                playerControl.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5882353f, 1, 0.3921569f);
                playerControl.buffList.Add(this);
            }
            else
            {
                buffPoison.timerA = 0;
            }
        }
        if (enemyControl != null)
        {
            BuffPoison buffPoison = (BuffPoison)enemyControl.buffList.Find((ABuff buff) => buff.buffType == BuffType.Poison);
            if (buffPoison == null)
            {
                enemyControl.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5882353f, 1, 0.3921569f);
                enemyControl.buffList.Add(this);
            }
            else
            {
                buffPoison.timerA = 0;
            }
        }
    }

    public override void OnBuffUpdate()
    {
        if (timerA < buffTime)
        {
            if (playerControl != null)
            {
                playerControl.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5882353f, 1, 0.3921569f);
                if (timerB > effectGapTime)
                {
                    if (!playerControl.isInvulnerable)
                    {
                        playerControl.playerHP -= minusHP;
                        Debug.Log("PlayerHP-" + minusHP);
                    }
                    timerB = 0;
                }
            }
            if (enemyControl != null)
            {
                enemyControl.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5882353f, 1, 0.3921569f);
                if (timerB > effectGapTime)
                {
                    if (!enemyControl.isInvulnerable)
                    {
                        enemyControl.enemyHP -= minusHP;
                        Debug.Log("EnemyHP-" + minusHP);
                    }
                    timerB = 0;
                }
            }
            timerB += Time.deltaTime;
            timerA += Time.deltaTime;
        }
        else
        {
            if (playerControl != null)
            {
                playerControl.buffRemoveList.Add(this);
            }
            if (enemyControl != null)
            {
                enemyControl.buffRemoveList.Add(this);
            }
        }
    }

    public override void OnBuffRemove()
    {
        if (playerControl != null)
        {
            playerControl.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            playerControl.buffList.Remove(this);
        }
        if (enemyControl != null)
        {
            enemyControl.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            enemyControl.buffList.Remove(this);
        }
    }
}
