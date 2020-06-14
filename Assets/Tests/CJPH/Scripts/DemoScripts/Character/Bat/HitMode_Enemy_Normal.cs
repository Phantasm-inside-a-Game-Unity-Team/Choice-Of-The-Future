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

    public override void BeHit(float atkPoint, List<ABuff> buffList, int effect)
    {
        float reducedHP = atkPoint - enemyControl.enemyDefensePoint;
        Debug.Log("enemyHP-" + reducedHP.ToString());
        enemyControl.enemyHP -= reducedHP;
        foreach (ABuff buff in buffList)    //将所有buff加到角色上
        {
            enemyControl.AddBuff(buff);
        }
    }
}
