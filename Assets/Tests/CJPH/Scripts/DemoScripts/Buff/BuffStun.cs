using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuffStun : ABuff
{
    private PlayerControl playerControl;
    private EnemyControl enemyControl;
    private float buffTime;         //buff持续时间
    private float timerA;           //用来对晕眩buff持续总时间的计时
    private GameObject stunPrefab;  //晕眩动画预设体

    public BuffStun(PlayerControl initPlayerControl, List<float> buffParaList)
    {
        playerControl = initPlayerControl;
        if (buffParaList.Count == 1)
        {
            buffTime = buffParaList[0];
        }
        else
        {
            buffTime = 2;
        }
        buffType = BuffType.Stun;
    }
    public BuffStun(EnemyControl initEnemyControl, List<float> buffParaList)
    {
        enemyControl = initEnemyControl;
        if (buffParaList.Count == 1)
        {
            buffTime = buffParaList[0];
        }
        else
        {
            buffTime = 2;
        }
        buffType = BuffType.Stun;
    }

    public override void OnBuffAdd()
    {
        if (playerControl != null)
        {
            BuffStun buffStun = (BuffStun)playerControl.buffList.Find((ABuff buff) => buff.buffType == BuffType.Stun);
            if (buffStun == null)
            {
                playerControl.buffList.Add(this);
                foreach (AAttackMode attackMode in playerControl.playerAttackModes)
                {
                    attackMode.isCannotAttack = true;
                }
                playerControl.playerMoveMode.isCannontMove = true;
                stunPrefab = (GameObject)Object.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Tests/CJPH/Resources/Stun/Stun.prefab", typeof(GameObject)));
                stunPrefab.transform.parent = playerControl.transform;
                stunPrefab.transform.localPosition = new Vector3(0, 0.5f, 0);
                playerControl.GetComponent<Animator>().SetBool("isWalk", false);
            }
            else
            {
                buffStun.timerA = 0;
            }
        }
        if (enemyControl != null)
        {
            BuffStun buffStun = (BuffStun)enemyControl.buffList.Find((ABuff buff) => buff.buffType == BuffType.Stun);
            if (buffStun == null)
            {
                enemyControl.buffList.Add(this);
                foreach (AAttackMode attackMode in enemyControl.enemyAttackModes)
                {
                    attackMode.isCannotAttack = true;
                }
                enemyControl.enemyMoveMode.isCannontMove = true;
                stunPrefab = (GameObject)Object.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Tests/CJPH/Resources/Stun/Stun.prefab", typeof(GameObject)));
                stunPrefab.transform.parent = enemyControl.transform;
                stunPrefab.transform.localPosition = new Vector3(0, 0.5f, 0);
            }
        }
    }

    public override void OnBuffUpdate()
    {
        if (timerA > buffTime)
        {
            if (playerControl != null)
            {
                OnBuffRemove();
            }
            if (enemyControl != null)
            {
                OnBuffRemove();
            }
        }
        timerA += Time.deltaTime;
    }

    public override void OnBuffRemove()
    {
        if (playerControl != null)
        {
            foreach (AAttackMode attackMode in playerControl.playerAttackModes)
            {
                attackMode.isCannotAttack = false;
            }
            playerControl.playerMoveMode.isCannontMove = false;
            playerControl.buffList.Remove(this);
        }
        if (enemyControl != null)
        {
            foreach (AAttackMode attackMode in enemyControl.enemyAttackModes)
            {
                attackMode.isCannotAttack = false;
            }
            enemyControl.enemyMoveMode.isCannontMove = false;
            enemyControl.buffList.Remove(this);
        }        
        GameObject.Destroy(stunPrefab);
    }
}
