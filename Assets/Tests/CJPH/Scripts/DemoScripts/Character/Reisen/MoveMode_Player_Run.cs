using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMode_Player_Run : AMoveMode
{
    public PlayerControl playerControl; //角色控制器
    public Animator playerAnimator;     //角色动画机
    public Rigidbody2D rb;              //角色的刚体
    public float dashSpeed;             //冲刺速度
    public float dashTime;              //冲刺持续时间
    float dashAvailableTime;            //剩余冲刺时间
    public float dashChargeTime;        //冲刺耗尽后的补充时间
    float chargeTime;                   //当前补充时间

    bool isWalk;                    //角色是否移动中
    float inputX;                   //左右按键
    float inputY;                   //上下按键

    void Start()
    {
        characterDirection.Set(0, 1);  //角色默认朝上
        dashAvailableTime = dashTime;
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
        playerAnimator.SetBool("isWalk", isWalk);
        if (isWalk)
        {
            characterDirection.Set(inputX, inputY);
            playerAnimator.SetFloat("moveX", characterDirection.x);
            playerAnimator.SetFloat("moveY", characterDirection.y);
        }
        rb.velocity = new Vector2(inputX * moveSpeed, inputY * moveSpeed);
        if (dashAvailableTime > 0)
        {
            if (Input.GetButton("Dash") && isWalk)
            {
                playerAnimator.speed = 2;
                rb.velocity = new Vector2(inputX * dashSpeed, inputY * dashSpeed);
                dashAvailableTime -= Time.deltaTime;
            }
            else
            {
                playerAnimator.speed = 1;
                dashAvailableTime += Time.deltaTime;
                dashAvailableTime = Mathf.Clamp(dashAvailableTime, dashAvailableTime, dashTime);
            }
        }
        else
        {
            playerAnimator.speed = 1;
            chargeTime += Time.deltaTime;
            if (chargeTime > dashChargeTime)
            {
                dashAvailableTime = dashTime;
                chargeTime = 0;
            }
        }
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
