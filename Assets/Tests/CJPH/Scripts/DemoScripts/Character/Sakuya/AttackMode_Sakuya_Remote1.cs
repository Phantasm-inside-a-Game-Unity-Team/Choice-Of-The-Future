using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMode_Sakuya_Remote1 : AAttackMode
{
    public GameObject bullentType;          //发射的子弹预设体
    public Vector3 relativeLaunchPosition;  //发射相对位置
    public int bullentNumber;               //一波发射数量
    public float bullentRange;              //子弹覆盖范围
    public int bullentWave;                 //一轮发射波数
    public int waveInterval;                //每波间隔
    public float chargeFront;                 //攻击前摇
    public float chargeBack;                  //攻击后摇
    public int life;                        //弹幕生存时间

    int chargeFrontCount;                   //前摇计数
    float chargeFinishTime;                  //蓄力完成时间（下次可攻击的时间点）
    PlayerControl playerMode;
    AMoveMode playerMove;
    public Transform playerTransform;

    public AudioSource attackSEsource;
    public AudioClip attackSE;

    // Use this for initialization
    void Awake()
    {
        if (bullentType == null)
        {
            Debug.LogWarning("The bullent is null");
        }
        chargeFrontCount = 0;
        chargeFinishTime = 0;
        playerMode = playerTransform.GetComponent<PlayerControl>();
        playerMove = playerMode.playerMoveMode;
        //attackSEsource.clip = attackSE;
    }

    public override void Attack()
    {
        if (cannotAttack)
            return;

        if (playerTransform.GetComponent<PlayerControl>().isDead)
            return;
        if (Input.GetButton("Attack1") && (Time.timeSinceLevelLoad > chargeFinishTime))    //按下攻击键且没有处于后摇中
        {
            chargeFrontCount += 1;
            if (chargeFrontCount > chargeFront)
            {
                //attackSEsource.Play();
                for (int i = 0; i < bullentWave; i++)   //进行数波发射
                {
                    Invoke("Launch", i * waveInterval / 60f);
                }
                chargeFinishTime = Time.timeSinceLevelLoad + chargeBack + (bullentWave - 1) * waveInterval;      //下次可攻击的时间点
                chargeFrontCount = 0;                   //前摇计数清零
            }
        }
        else
        {
            chargeFrontCount = 0;
        }
    }

    public override void PowerUp(int power)
    {
        if ((bullentNumber + power) > 5)
        {
            bullentNumber = 5;
        }
        else
        {
            bullentNumber += power;
        }
    }

    public void Launch()
    {
        float directionAngle = playerMove.directionAngle;
        int depth = 0;
        if (directionAngle < 1.107f && directionAngle > -1.107f)
        {
            depth = 1;
        }
        else
        {
            depth = -1;
        }
        Vector3 LaunchPosition = transform.position + new Vector3(relativeLaunchPosition.x * Mathf.Cos(directionAngle) - relativeLaunchPosition.y * Mathf.Sin(directionAngle), relativeLaunchPosition.x * Mathf.Sin(directionAngle) + relativeLaunchPosition.y * Mathf.Cos(directionAngle), depth); //计算旋转后的偏移位置
        if (bullentNumber == 1)
        {
            GameObject bullentIns = (GameObject)Instantiate(bullentType, LaunchPosition, Quaternion.Euler(0, 0, directionAngle * Mathf.Rad2Deg));
            //bullentIns.transform.parent = DemoSceneManager.Instance.playerBullentsObj.transform;
            bullentIns.GetComponent<Bullent_Sakuya_01>().life = life;
        }
        else
        {
            for (int i = 0; i < bullentNumber; i++)
            {
                GameObject bullentIns = (GameObject)Instantiate(bullentType, LaunchPosition, Quaternion.Euler(0, 0, directionAngle * Mathf.Rad2Deg - bullentRange / 2 + i * bullentRange / (bullentNumber - 1)));
                //bullentIns.transform.parent = DemoSceneManager.Instance.playerBullentsObj.transform;
                bullentIns.GetComponent<Bullent_Sakuya_01>().life = life;
            }
        }
    }
}
