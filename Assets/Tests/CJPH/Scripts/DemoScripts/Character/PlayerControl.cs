using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    //UI显示的属性
    public float playerMaxLife;                 //玩家残机最大值
    public float playerLife;                    //玩家残机
    public float playerMaxHP;                   //玩家最大HP
    public float playerHP;                      //玩家当前HP
    public float maxPPoint;                     //角色最大P点
    public float pPoint;                        //角色当前P点
    public float maxBluePoint;                  //角色最大蓝点
    public float bluePoint;                     //角色当前蓝点
    public int maxBeer;                         //回血道具最大携带量
    public int beer;                            //回血道具当前数量
    public List<ABuff> buffList;                //所有BUFF的列表

    public bool isMainPlayer;                   //是否是主角色
    public PlayerControl changePlayer;          //可更换的角色
    public float playerChangeTime;              //两次更换的间隔时间
    float timeAfterChange;                      //记录一次更换后的时间
    public float playerBaseAtk;                 //角色基础攻击力
    public float playerBaseDef;                 //角色基础防御力
    [HideInInspector]
    public float playerAttackPoint;             //角色攻击力
    [HideInInspector]
    public float playerDefensePoint;            //角色防御力

    public Animator playerAnimator;             //角色动画机
    public List<string> attackButtons;          //攻击按键列表
    public List<AAttackMode> playerAttackModes; //玩家攻击模块列表
    public AMoveMode playerMoveMode;            //玩家移动模块
    public AHitMode playerHitMode;              //玩家受伤模块
    public float playerSize;                    //玩家判定大小（暂时没用，使用的胶囊形碰撞体）
    [HideInInspector]
    public bool isDead;                         //玩家角色是否死亡
    [HideInInspector]
    public bool isChanging;                     //玩家正在切换角色


    // Use this for initialization
    void Start()
    {
        buffList = new List<ABuff>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMainPlayer)
            return;

        for (int i = 0; i < buffList.Count; i++)
        {
            buffList[i].OnBuffUpdate();
        }
        IsAlive();
        PlayerChange();
        ParameterCalculate();
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

    //角色生死相关操作
    void IsAlive()
    {
        if (playerHP <= 0)
        {
            isDead = true;
            playerAnimator.SetBool("isDead", true);
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
        if (isDead)
        {
            AnimatorStateInfo playerAniInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
            if (playerAniInfo.IsName("Die") && playerAniInfo.normalizedTime > 1.0f)
            {
                if (playerLife > 0)     //有剩余残机
                {
                    Reborn();
                }
                else
                {
                    ManShenChuangYi();
                }
            }
        }
    }
    //角色各种属性的上限限制和计算
    void ParameterCalculate()
    {
        playerLife = Mathf.Clamp(playerLife, playerLife, playerMaxLife);
        playerHP = Mathf.Clamp(playerHP, playerHP, playerMaxHP);
        pPoint = Mathf.Clamp(pPoint, 0, maxPPoint);
        bluePoint = Mathf.Clamp(bluePoint, 0, maxBluePoint);
        //攻击力防御力后续可能调整计算公式
        playerAttackPoint = playerBaseAtk + pPoint;
        playerDefensePoint = playerBaseDef;
    }
    //有残机时重生
    void Reborn()
    {
        playerLife--;
        playerHP = playerMaxHP;
        gameObject.transform.position = DemoSceneManager.Instance.rebirthPoint;
        isDead = false;
        playerAnimator.SetBool("isDead", false);
        GetComponent<CapsuleCollider2D>().enabled = true;
        isChanging = false;
        playerAnimator.SetBool("isChanging", false);
        while(buffList.Count>0)
        {
            RemoveBuff(buffList[0]);
        }
    }
    //没有残机时死亡
    void ManShenChuangYi()
    {
        gameObject.transform.position = new Vector3(0, 10, 0);
    }
    //角色切换判断
    void PlayerChange()
    {
        if (isDead)
            return;
        if (Input.GetButtonDown("Change") && timeAfterChange > playerChangeTime)
        {
            Debug.Log("change");
            isChanging = true;
            playerAnimator.SetBool("isChanging", true);
            for (int i = 0; i < playerAttackModes.Count; i++)
            {
                playerAttackModes[i].isCannotAttack = true;
            }
            playerMoveMode.isCannotSpecialMove = true;
        }
        if (isChanging)
        {
            AnimatorStateInfo playerAniInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
            if (playerAniInfo.IsName("Change") && playerAniInfo.normalizedTime > 1.0f)
            {
                changePlayer.gameObject.SetActive(true);
                changePlayer.isMainPlayer = true;
                changePlayer.gameObject.transform.position = transform.position;
                changePlayer.playerMoveMode.SetDirection(playerMoveMode.characterDirection);
                isMainPlayer = false;
                timeAfterChange = 0;
                DemoSceneManager.Instance.mainPlayer = changePlayer.gameObject;
                DemoSceneManager.Instance.subPlayer = gameObject;
                gameObject.SetActive(false);
                isChanging = false;
                playerAnimator.SetBool("isChanging", false);
                for (int i = 0; i < playerAttackModes.Count; i++)
                {
                    playerAttackModes[i].isCannotAttack = false;
                }
                playerMoveMode.isCannotSpecialMove = false;
            }
        }
        timeAfterChange += Time.deltaTime;
    }
    //添加BUFF
    public void AddBuff(ABuff buff)
    {
        buffList.Add(buff);
        buff.OnBuffAdd();
    }
    //移除BUFF
    public void RemoveBuff(ABuff buff)
    {
        if (buffList.Contains(buff))
        {
            buffList.Remove(buff);
            buff.OnBuffRemove();
        }
    }

    //设置攻击、移动、被击模式
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
    //获取当前列表中攻击模式编号
    public int GetAttackModeIndex(int index)
    {
        return playerAttackModes[index].attackModeIndex;
    }
    //获取当前列表中攻击模式名称
    public string GetAttackModeName(int index)
    {
        return playerAttackModes[index].attackModeName;
    }
}
