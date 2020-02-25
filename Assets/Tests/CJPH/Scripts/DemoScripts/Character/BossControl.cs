using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BOSS脚本暂未使用
public class BossControl : MonoBehaviour
{
    public Animator bossAnimator;               //BOSS动画机
    public List<AAttackMode> bossAttackModes;   //BOSS攻击模块
    public AMoveMode bossMoveMode;              //BOSS移动模块
    public AHitMode bossHitMode;                //BOSS受伤模块
    public float bossSize;                      //BOSS判定大小
    public float bossMaxLife;                   //BOSS残机最大值
    public float bossLife;                      //BOSS当前残机
    public float bossMaxHP;                     //BOSS最大HP
    public float bossHP;                        //BOSS当前HP
    public float bossAttackPoint;               //BOSS攻击力
    public float bossDefensePoint;              //BOSS防御力
    public bool isDead;                         //BOSS是否死亡
    public float hatredRange;                   //仇恨距离
    public List<GameObject> itemDropped;        //掉落物品
    [Range(0, 1)]
    public List<float> droppedRate;             //掉落率

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        IsAlive();
        for (int i = 0; i < bossAttackModes.Count; i++)
        {
            bossAttackModes[i].AttackButtonDown();
        }
        bossMoveMode.Move();
        bossHitMode.Hit();
    }
    void IsAlive()
    {
        if (bossHP <= 0)
        {
            isDead = true;
            bossAnimator.SetBool("isDied", true);
            GetComponent<CircleCollider2D>().enabled = false;
        }
        if (isDead)
        {
            AnimatorStateInfo playerAniInfo = bossAnimator.GetCurrentAnimatorStateInfo(0);
            if (playerAniInfo.IsName("Die") && playerAniInfo.normalizedTime > 1.0f)
            {
                DemoSceneManager.Instance.enemies.Remove(gameObject);
                for (int i = 0; i < droppedRate.Count; i++)
                {
                    if (Random.value <= droppedRate[i])
                    {
                        Instantiate(itemDropped[i], transform.position, Quaternion.identity);
                    }
                }
                Destroy(gameObject);
            }
        }
    }
    public void SetAttackMode(AAttackMode attackMode, int index)
    {
        bossAttackModes[index] = attackMode;
    }

    public void SetMoveMode(AMoveMode moveMode)
    {
        bossMoveMode = moveMode;
    }

    public void SetHitMode(AHitMode hitMode)
    {
        bossHitMode = hitMode;
    }

    //获取当前攻击模式编号
    public int GetAttackModeIndex(int index)
    {
        return bossAttackModes[index].attackModeIndex;
    }
    //获取当前攻击模式名称
    public string GetAttackModeName(int index)
    {
        return bossAttackModes[index].attackModeName;
    }
}
