using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffFrozen : ABuff
{
    private PlayerControl playerControl;
    private EnemyControl enemyControl;
    private float buffTime;             //buff持续时间
    private float slowdownScale;        //减速比例
    private float timerA;               //用来对毒buff持续总时间的计时

    public BuffFrozen(PlayerControl initPlayerControl, List<float> buffParaList)
    {
        playerControl = initPlayerControl;
        if (buffParaList.Count == 2)
        {
            buffTime = buffParaList[0];
            slowdownScale = buffParaList[1];
        }
        else
        {
            buffTime = 5;
            slowdownScale = 0.3f;
        }
        buffType = BuffType.Frozen;
    }
    public BuffFrozen(EnemyControl initEnemyControl, List<float> buffParaList)
    {
        enemyControl = initEnemyControl;
        if (buffParaList.Count == 3)
        {
            buffTime = buffParaList[0];
            slowdownScale = buffParaList[1];
        }
        else
        {
            buffTime = 5;
            slowdownScale = 0.3f;
        }
        buffType = BuffType.Frozen;
    }

    public override void OnBuffAdd()
    {
        if (playerControl != null)
        {
            BuffFrozen buffFrozen = (BuffFrozen)playerControl.buffList.Find((ABuff buff) => buff.buffType == BuffType.Frozen);
            if (buffFrozen == null)
            {
                playerControl.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.75f, 1);
                playerControl.playerMoveMode.moveSpeed *= slowdownScale;
                playerControl.buffList.Add(this);
                timerA = 0;
            }
            else
            {
                buffFrozen.timerA = 0;
            }
        }
        if (enemyControl != null)
        {
            BuffFrozen buffFrozen = (BuffFrozen)enemyControl.buffList.Find((ABuff buff) => buff.buffType == BuffType.Poison);
            if (buffFrozen == null)
            {
                enemyControl.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.75f, 1);
                playerControl.playerMoveMode.moveSpeed *= slowdownScale;
                enemyControl.buffList.Add(this);
            }
            else
            {
                buffFrozen.timerA = 0;
            }
        }
    }

    public override void OnBuffUpdate()
    {
        if (timerA < buffTime)
        {
            if (playerControl != null)
            {
                playerControl.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.75f, 1);
            }
            if (enemyControl != null)
            {
                enemyControl.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.45f, 0.75f, 1);
            }
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
            if (playerControl.playerMoveMode.moveSpeed != 0)
            {
                playerControl.playerMoveMode.moveSpeed /= slowdownScale;
            }
            playerControl.buffList.Remove(this);
        }
        if (enemyControl != null)
        {
            enemyControl.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            if (enemyControl.enemyMoveMode.moveSpeed != 0)
            {
                enemyControl.enemyMoveMode.moveSpeed /= slowdownScale;
            }
            enemyControl.buffList.Remove(this);
        }
    }
}
