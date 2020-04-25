using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMode_Player_Shield : AAttackMode
{
    public float shieldHP;                  //护盾HP
    public float shieldTime;                //护盾持续时间
    public float chargeTime;                //护盾技能CD

    public PlayerControl playerControl;     //角色控制器
    public GameObject shieldProbeb;         //护盾预设体

    private GameObject shieldObj;                   //护盾物体
    private float timerA;                           //用来对护盾技能CD时间的计时
    private bool isShieldOn;                        //是否有护盾
    private List<float> thisBuffPara;               //buff参数

    // Start is called before the first frame update
    void Start()
    {
        timerA = chargeTime;
        thisBuffPara = new List<float>();
        thisBuffPara.Add(shieldHP);
        thisBuffPara.Add(shieldTime);
    }

    // Update is called once per frame
    void Update()
    {
        timerA += Time.deltaTime;
    }

    public override void AttackButtonDown()
    {
        if (isCannotAttack || playerControl.isDead)
        {
            return;
        }
        if (timerA > chargeTime)
        {
            playerControl.AddBuff(BuffGroup.CreateBuff(playerControl, BuffType.Shield, thisBuffPara));
            timerA = 0;
        }
    }

    public override void AttackButtonUp()
    {

    }

    public override void PowerUp(int power)
    {

    }
}
