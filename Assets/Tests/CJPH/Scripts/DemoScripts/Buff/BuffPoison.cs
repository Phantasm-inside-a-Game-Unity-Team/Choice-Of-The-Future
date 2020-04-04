using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffPoison : ABuff
{
    public PlayerControl playerControl;
    public EnemyControl enemyControl;
    public float buffTime;
    public float minusHP;
    public float effectGapTime;
    float timeElapsed;
    float onceTimeElased;

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
            buffTime = 3;
            minusHP = 0.5f;
            effectGapTime = 1;
        }
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
            buffTime = 3;
            minusHP = 0.5f;
            effectGapTime = 1;
        }
    }



    public override void OnBuffAdd()
    {
        if (playerControl != null)
        {
            playerControl.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5882353f, 1, 0.3921569f);
        }
        if (enemyControl != null)
        {
            enemyControl.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5882353f, 1, 0.3921569f);
        }
    }

    public override void OnBuffUpdate()
    {
        if (timeElapsed < buffTime)
        {
            if (onceTimeElased > effectGapTime)
            {
                if (playerControl != null)
                {
                    playerControl.playerHP -= minusHP;
                }
                if (enemyControl != null)
                {
                    enemyControl.enemyHP -= minusHP;
                }
                onceTimeElased = 0;
            }
            onceTimeElased += Time.deltaTime;
            timeElapsed += Time.deltaTime;
        }
        else
        {
            if (playerControl != null)
            {
                playerControl.RemoveBuff(this);
            }
            if (enemyControl != null)
            {
                enemyControl.RemoveBuff(this);
            }
        }
    }

    public override void OnBuffRemove()
    {
        if (playerControl != null)
        {
            playerControl.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        }
        if (enemyControl != null)
        {
            enemyControl.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        }
    }
}
