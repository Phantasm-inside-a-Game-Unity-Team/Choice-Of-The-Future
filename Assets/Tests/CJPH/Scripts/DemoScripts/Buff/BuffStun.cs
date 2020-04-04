using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuffStun : ABuff
{
    public PlayerControl playerControl;
    public EnemyControl enemyControl;
    public float buffTime;
    float timeElapsed;
    GameObject stunPrefab;

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

    }


    public override void OnBuffAdd()
    {
        if (playerControl != null)
        {
            stunPrefab = (GameObject)Object.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Tests/CJPH/Resources/Stun/Stun.prefab", typeof(GameObject)));
            stunPrefab.transform.parent = playerControl.transform;
            stunPrefab.transform.localPosition = new Vector3(0, 0.5f, 0);
            foreach (AAttackMode attackMode in playerControl.playerAttackModes)
            {
                attackMode.isCannotAttack = true;
            }
            playerControl.playerMoveMode.isCannontMove = true;
        }
        if (enemyControl != null)
        {
            stunPrefab = (GameObject)Object.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Tests/CJPH/Resources/Stun/Stun.prefab", typeof(GameObject)));
            stunPrefab.transform.parent = enemyControl.transform;
            stunPrefab.transform.localPosition = new Vector3(0, 0.5f, 0);
            foreach (AAttackMode attackMode in enemyControl.enemyAttackModes)
            {
                attackMode.isCannotAttack = true;
            }
            enemyControl.enemyMoveMode.isCannontMove = true;
        }
    }

    public override void OnBuffUpdate()
    {
        if (timeElapsed > buffTime)
        {
            if (playerControl != null)
            {
                playerControl.RemoveBuff(this);
            }
            if (enemyControl != null)
            {
                enemyControl.RemoveBuff(this);
            }
        }
        timeElapsed += Time.deltaTime;
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
        }
        if (enemyControl != null)
        {
            foreach (AAttackMode attackMode in enemyControl.enemyAttackModes)
            {
                attackMode.isCannotAttack = false;
            }
            enemyControl.enemyMoveMode.isCannontMove = false;
        }
        GameObject.Destroy(stunPrefab);
    }
}
