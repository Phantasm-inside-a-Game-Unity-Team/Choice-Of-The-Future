using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMode_Player_Normal : AHitMode
{
    public float invincibleTime;
    public PlayerControl playerControl;
    public SpriteRenderer playerSprite;
    private float TimerA;
    private float hitTime;

    public override void Hit()
    {
        if (playerControl.isHit)
        {
            var r = playerSprite.color.r;
            var g = playerSprite.color.g;
            var b = playerSprite.color.b;
            var alpha = Mathf.PingPong((Time.time - hitTime) * 10f + 1f, 1);
            playerSprite.color = new Color(r, g, b, alpha);
            TimerA -= Time.deltaTime;
            if (TimerA < 0)
            {
                playerControl.isHit = false;
            }
        }
    }

    public override void BeHit(float atkPoint, List<ABuff> buffList, int effect)
    {
        if (playerControl.isInvulnerable || playerControl.isHit)
        {
            return;
        }

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
            foreach (ABuff buff in buffList)    //将所有buff加到角色上
            {
                playerControl.AddBuff(buff);
            }
        }

        hitTime = Time.time;
        TimerA = invincibleTime;
        playerControl.isHit = true;
    }
}
