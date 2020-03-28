using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuffPoison : ABuff
{
    public PlayerControl playerControl;
    public float buffTime;
    public float minusHP;
    public float effectGapTime;
    float timeElapsed;
    float onceTimeElased;

    public PlayerBuffPoison(PlayerControl initPlayerControl, BuffPoisonPara buffPara)
    {
        playerControl = initPlayerControl;
        buffTime = buffPara.buffTime;
        minusHP = buffPara.minusHP;
        effectGapTime = buffPara.effectGapTime;
    }

    public override void OnBuffAdd()
    {
        playerControl.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5882353f, 1, 0.3921569f);
    }

    public override void OnBuffUpdate()
    {
        if (timeElapsed < buffTime)
        {
            if (onceTimeElased > effectGapTime)
            {
                playerControl.playerHP -= minusHP;
                onceTimeElased = 0;
            }
            onceTimeElased += Time.deltaTime;
            timeElapsed += Time.deltaTime;
        }
        else
        {
            playerControl.RemoveBuff(this);
        }
    }

    public override void OnBuffRemove()
    {
        playerControl.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }
}
