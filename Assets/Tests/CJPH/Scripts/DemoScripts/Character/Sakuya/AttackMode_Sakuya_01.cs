using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMode_Sakuya_01 : AAttackMode
{
    public GameObject bullentType;          //发射的子弹预设体
    public Vector3 relativeLaunchPosition;  //发射相对位置
    public float relativeLaunchAngle;       //发射相对角度（角度值，向前为0度，逆时针为正）
    public int bullentNumber;               //一波发射数量
    public float bullentRange;              //子弹覆盖范围
    public int bullentWave;                 //一轮发射波数
    public float waveInterval;              //每波间隔
    public float chargeFront;               //攻击前摇
    public float chargeBack;                //攻击后摇
    public float life;                      //弹幕生存时间
    public bool isCloseAttack;              //是否近战

    Vector3 launchPosition;                 //实际发射位置
    float launchAngle;                      //实际发射角度
    float directionAngle;                   //角色方向角（角色朝向与y轴的夹角（弧度，逆时针为正向））
    float chargeFrontTime;                  //前摇计时
    float nextAttackableTime;               //下次可攻击的时间点
    public PlayerControl playerControl;     //角色控制器
    AMoveMode playerMoveMode;               //角色移动模式

    public AudioSource attackSEsource;
    public AudioClip attackSE;

    // Use this for initialization
    void Awake()
    {
        if (bullentType == null)
        {
            Debug.LogWarning("The bullent is null");
        }
        chargeFrontTime = 0;
        nextAttackableTime = 0;
        playerMoveMode = playerControl.playerMoveMode;
        //attackSEsource.clip = attackSE;
    }

    public override void Attack()
    {
        if (cannotAttack || playerControl.isDead)
        {
            chargeFrontTime = 0;
            return;
        }

        if (Input.GetButton("Attack1") && (Time.timeSinceLevelLoad > nextAttackableTime))    //按下攻击键且没有处于后摇中
        {
            chargeFrontTime += Time.deltaTime;
            if (chargeFrontTime > chargeFront)
            {
                for (int i = 0; i < bullentWave; i++)   //进行数波发射
                {
                    Invoke("Launch", i * waveInterval / 60f);
                }
                nextAttackableTime = Time.timeSinceLevelLoad + chargeBack + (bullentWave - 1) * waveInterval;      //下次可攻击的时间点
                chargeFrontTime = 0;                   //前摇计时清零
            }
        }
        else
        {
            chargeFrontTime = 0;
        }
    }

    public override void PowerUp(int power)
    {

    }

    public void Launch()
    {
        directionAngle = playerMoveMode.directionAngle;
        launchAngle = directionAngle + relativeLaunchAngle * Mathf.Deg2Rad;
        launchPosition = transform.position + Quaternion.AngleAxis(launchAngle * Mathf.Rad2Deg, Vector3.forward) * relativeLaunchPosition; //计算旋转后的偏移位置
        if (bullentNumber == 1)
        {
            GameObject bullentIns = (GameObject)Instantiate(bullentType, launchPosition, Quaternion.Euler(0, 0, launchAngle * Mathf.Rad2Deg));
            bullentIns.GetComponent<ABullent>().life = life;
            if (isCloseAttack)
            {
                bullentIns.transform.parent = transform;
            }
        }
        else
        {
            for (int i = 0; i < bullentNumber; i++)
            {
                GameObject bullentIns = (GameObject)Instantiate(bullentType, launchPosition, Quaternion.Euler(0, 0, launchAngle * Mathf.Rad2Deg - bullentRange / 2 + i * bullentRange / (bullentNumber - 1)));
                bullentIns.GetComponent<ABullent>().life = life;
                if (isCloseAttack)
                {
                    bullentIns.transform.parent = transform;
                }
            }
        }
        //attackSEsource.Play();
    }
}
