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
        float reducedHP = atkPoint - playerControl.playerDefensePoint;
        Debug.Log("playerHP-" + reducedHP.ToString());
        playerControl.playerHP -= reducedHP;
    }
}
