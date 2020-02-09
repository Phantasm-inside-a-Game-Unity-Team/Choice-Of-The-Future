using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public List<string> attackButtons;          //攻击按键列表
    public List<AAttackMode> playerAttackModes; //玩家攻击模块列表
    public AMoveMode playerMoveMode;            //玩家移动模块
    public AHitMode playerHitMode;              //玩家受伤模块
    public float playerSize;                    //玩家判定大小
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
    }
    void IsAlive()
    {

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
