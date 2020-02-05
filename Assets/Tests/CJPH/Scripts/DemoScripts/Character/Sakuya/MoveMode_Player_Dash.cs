using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMode_Player_Dash : AMoveMode
{
    public Animator playerAnimator; //角色动画机
    public Rigidbody2D rb;          //角色的刚体
    public float dashTime;          //冲刺持续时间
    public float dashSpeed;         //冲刺速度
    public float dashChargeTime;    //冲刺后摇
    public PlayerControl playerControl; //角色控制器

    bool isMove;                    //角色是否移动中
    float inputX;                   //左右按键
    float inputY;                   //上下按键
    float DirectionX;               //角色左右朝向
    float DirectionY;               //角色上下朝向
    bool isDash;                    //角色是否冲刺中
    float dashStartTime;            //角色冲刺开始时间
    Vector2 playerDirection;        //角色朝向    

    void Start()
    {
        DirectionY = 1;
        playerDirection.Set(0, 1);
    }
    public override void Move()
    {
        if (cannontMove)
            return;

        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        directionAngle = Vector2.SignedAngle(Vector2.up, playerDirection) * Mathf.Deg2Rad;
        isMove = !(inputX == 0 && inputY == 0);
        if (Input.GetButtonDown("Dash") && isMove && !isDash && (Time.timeSinceLevelLoad - dashStartTime - dashTime) > dashChargeTime)
        {
            isDash = true;
            dashStartTime = Time.timeSinceLevelLoad;
            playerAnimator.SetBool("isDash", true);
            playerControl.playerAttackMode.cannotAttack = true;
        }
        if (isDash)
        {
            rb.velocity = new Vector2(DirectionX * dashSpeed, DirectionY * dashSpeed);
            if ((Time.time - dashStartTime) > dashTime)
            {
                isDash = false;
                playerAnimator.SetBool("isDash", false);
                playerControl.playerAttackMode.cannotAttack = false;
            }
            return;
        }
        playerAnimator.SetBool("isMove", isMove);
        if (isMove)
        {
            DirectionX = inputX;
            DirectionY = inputY;
            playerDirection.Set(inputX, inputY);
            playerAnimator.SetFloat("moveX", DirectionX);
            playerAnimator.SetFloat("moveY", DirectionY);
        }
        rb.velocity = new Vector2(inputX * moveSpeed, inputY * moveSpeed);
    }

    public override void IsDelayed()
    {
        //throw new System.NotImplementedException();
    }
}
