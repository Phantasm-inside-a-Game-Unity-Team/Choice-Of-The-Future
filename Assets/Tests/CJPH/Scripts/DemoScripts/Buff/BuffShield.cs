using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuffShield : ABuff
{
    private PlayerControl playerControl;
    private EnemyControl enemyControl;
    private float shieldHP;             //护盾血量
    private float shieldTime;           //护盾持续时间
    private float timerA;               //用来对护盾持续时间的计时
    private GameObject shieldPrefab;    //护盾动画预设体

    public BuffShield(PlayerControl initPlayerControl, List<float> buffParaList)
    {
        this.playerControl = initPlayerControl;
        if (buffParaList.Count == 2)
        {
            shieldHP = buffParaList[0];
            shieldTime = buffParaList[1];
        }
        else
        {
            shieldHP = 5;
            shieldTime = 5;
        }
        buffType = BuffType.Shield;
    }

    public BuffShield(EnemyControl initEnemyControl, List<float> buffParaList)
    {
        this.enemyControl = initEnemyControl;
        if (buffParaList.Count == 2)
        {
            shieldHP = buffParaList[0];
            shieldTime = buffParaList[1];
        }
        else
        {
            shieldHP = 5;
            shieldTime = 5;
        }
        buffType = BuffType.Shield;
    }

    public override void OnBuffAdd()
    {
        if (playerControl != null)
        {
            BuffShield buffShield = (BuffShield)playerControl.buffList.Find((ABuff buff) => buff.buffType == BuffType.Shield);
            if (buffShield == null)
            {
                playerControl.buffList.Add(this);
                playerControl.shieldHP = shieldHP;
                shieldPrefab = (GameObject)Object.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Tests/CJPH/Resources/Shield/Shield.prefab", typeof(GameObject)));
                shieldPrefab.transform.SetParent(playerControl.transform);
                shieldPrefab.transform.localPosition = Vector3.zero;
            }
            else
            {
                playerControl.shieldHP = shieldHP;
                timerA = 0;
            }
        }
        if (enemyControl != null)
        {
            BuffShield buffShield = (BuffShield)enemyControl.buffList.Find((ABuff buff) => buff.buffType == BuffType.Shield);
            if (buffShield == null)
            {
                enemyControl.buffList.Add(this);
                enemyControl.shieldHP = shieldHP;
                shieldPrefab = (GameObject)Object.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Tests/CJPH/Resources/Shield/Shield.prefab", typeof(GameObject)));
                shieldPrefab.transform.SetParent(enemyControl.transform);
                shieldPrefab.transform.localPosition = Vector3.zero;
            }
            else
            {
                enemyControl.shieldHP = shieldHP;
                timerA = 0;
            }
        }
    }

    public override void OnBuffUpdate()
    {
        if (playerControl != null)
        {
            if (timerA > shieldTime || playerControl.shieldHP <= 0)
            {
                OnBuffRemove();
            }
        }
        if (enemyControl != null)
        {
            if (timerA > shieldTime || enemyControl.shieldHP <= 0)
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
            playerControl.buffList.Remove(this);
            playerControl.shieldHP = 0;
        }
        if (enemyControl != null)
        {
            enemyControl.buffList.Remove(this);
            enemyControl.shieldHP = 0;
        }
        GameObject.Destroy(shieldPrefab);
    }
}
