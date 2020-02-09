using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMode_Player_Normal : AHitMode
{
    public override void Hit()
    {
        
    }

    public override void BeHit(int atkPoint, int effect)
    {
        Debug.Log("playerHP-"+atkPoint.ToString());
    }
}
