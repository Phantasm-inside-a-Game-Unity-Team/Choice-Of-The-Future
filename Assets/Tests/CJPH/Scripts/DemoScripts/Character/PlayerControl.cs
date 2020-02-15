using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public Animator playerAnimator;             //角色动画机
    public List<string> attackButtons;          //攻击按键列表
    public List<AAttackMode> playerAttackModes; //玩家攻击模块列表
    public AMoveMode playerMoveMode;            //玩家移动模块
    public AHitMode playerHitMode;              //玩家受伤模块
    public float playerSize;                    //玩家判定大小（暂时没用，使用的胶囊形碰撞体）
    public float playerLife;                    //玩家残机
    public int playerMaxHP;                     //玩家HP最大值
    public int playerHP;                        //玩家HP
    public bool isDead;                         //玩家角色是否死亡


    // Use this for initialization
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < attackButtons.Count; i++)
        {
            if (Input.GetButton(attackButtons[i]))
            {
                playerAttackModes[i].AttackButtonDown();
            }
            else
            {
                playerAttackModes[i].AttackButtonUp();
            }
        }
        playerMoveMode.Move();
        playerHitMode.Hit();
        IsAlive();
    }
    void IsAlive()
    {
        if (playerHP <= 0)
        {
            playerLife--;
            playerHP = playerMaxHP;
        }
        if (playerLife < 0)
        {
            isDead = true;
            playerAnimator.SetBool("isDead", true);
        }
        if (isDead)
        {
            AnimatorStateInfo playerAniInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
            if (playerAniInfo.IsName("Die") && playerAniInfo.normalizedTime > 1.0f)
            {
                gameObject.SetActive(false);
            }
            return;
        }
    }
    public void SetAttackMode(AAttackMode attackMode, int index)
    {
        playerAttackModes[index] = attackMode;
    }

    public void SetMoveMode(AMoveMode moveMode)
    {
        playerMoveMode = moveMode;
    }

    public void SetHitMode(AHitMode hitMode)
    {
        playerHitMode = hitMode;
    }
}
