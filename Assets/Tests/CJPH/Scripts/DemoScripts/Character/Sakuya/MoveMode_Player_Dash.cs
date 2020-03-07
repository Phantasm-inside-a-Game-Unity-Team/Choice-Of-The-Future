using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMode_Player_Dash : AMoveMode
{
    public PlayerControl playerControl; //角色控制器
    public Animator playerAnimator;     //角色动画机
    public Rigidbody2D rb;              //角色的刚体
    public float dashSpeed;             //冲刺速度
    public float dashTime;              //冲刺持续时间
    public float dashChargeTime;        //冲刺后摇

    bool isWalk;                        //角色是否移动中
    float inputX;                       //左右按键
    float inputY;                       //上下按键
    bool isDash;                        //角色是否冲刺中
    float dashStartTime;                //角色冲刺开始时间

    void Start()
    {
        SetDirection(Vector2.up);  //角色默认朝上
    }
    public override void Move()
    {
        if (isCannontMove || playerControl.isDead)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        directionAngle = Vector2.SignedAngle(Vector2.up, characterDirection);
        isWalk = !(inputX == 0 && inputY == 0);
        if (Input.GetButtonDown("Dash") && isWalk && !isDash && (Time.timeSinceLevelLoad - dashStartTime - dashTime) > dashChargeTime)
        {
            if (isCannotSpecialMove)
                return;
            isDash = true;
            dashStartTime = Time.timeSinceLevelLoad;
            playerAnimator.SetBool("isDash", true);
            foreach (var attackMode in playerControl.playerAttackModes)
            {
                attackMode.isCannotAttack = true;
            }
        }
        if (isDash)
        {
            rb.velocity = new Vector2(characterDirection.x * dashSpeed, characterDirection.y * dashSpeed);
            if ((Time.time - dashStartTime) > dashTime)
            {
                isDash = false;
                playerAnimator.SetBool("isDash", false);
                foreach (var attackMode in playerControl.playerAttackModes)
                {
                    attackMode.isCannotAttack = false;
                }
            }
            return;
        }
        playerAnimator.SetBool("isWalk", isWalk);
        if (isWalk)
        {
            characterDirection.Set(inputX, inputY);
            playerAnimator.SetFloat("moveX", characterDirection.x);
            playerAnimator.SetFloat("moveY", characterDirection.y);
        }
        rb.velocity = new Vector2(inputX * moveSpeed, inputY * moveSpeed);
    }

    public override void IsDelayed()
    {
        //硬直时的操作
    }

    public override void SetDirection(Vector2 direction)
    {
        playerAnimator.SetFloat("moveX", direction.x);
        playerAnimator.SetFloat("moveY", direction.y);
        characterDirection = direction;
    }
}
