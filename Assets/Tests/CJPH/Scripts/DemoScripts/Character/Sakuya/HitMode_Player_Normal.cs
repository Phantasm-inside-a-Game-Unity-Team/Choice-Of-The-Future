using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMode_Player_Normal : AHitMode
{
    public PlayerControl playerControl;
    public override void Hit()
    {

    }

    public override void BeHit(float atkPoint, int effect)
    {
        float damagePoint = atkPoint - playerControl.playerDefensePoint;
        if (playerControl.shieldHP > 0)
        {
            playerControl.shieldHP -= damagePoint;
            Debug.Log("shieldHP-" + damagePoint.ToString());
        }
        else
        {
            Debug.Log("playerHP-" + damagePoint.ToString());
            playerControl.playerHP -= damagePoint;
        }
    }
}
