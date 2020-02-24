using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMode_Enemy_Normal : AHitMode
{
    public EnemyControl enemyControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Hit()
    {
        
    }

    public override void BeHit(float atkPoint, int effect)
    {
        float reducedHP = atkPoint - enemyControl.enemyDefensePoint;
        Debug.Log("enemyHP-" + reducedHP.ToString());
        enemyControl.enemyHP -= reducedHP;
    }
}
