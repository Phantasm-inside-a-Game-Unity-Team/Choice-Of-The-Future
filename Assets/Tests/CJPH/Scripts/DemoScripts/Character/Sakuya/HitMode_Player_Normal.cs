using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMode_Player_Normal : AHitMode
{
    public PlayerControl playerControl;
    public override void Hit()
    {
        
    }

    public override void BeHit(int atkPoint, int effect)
    {
        Debug.Log("playerHP-"+atkPoint.ToString());
        playerControl.playerHP -= atkPoint;
    }
}
