using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//空buff，相当于没有
public class BuffBlank : ABuff
{
    private PlayerControl playerControl;
    private EnemyControl enemyControl;

    public BuffBlank(PlayerControl playerControl)
    {
        this.playerControl = playerControl;
    }

    public BuffBlank(EnemyControl enemyControl)
    {
        this.enemyControl = enemyControl;
    }
    public override void OnBuffAdd()
    {
        if (playerControl != null)
        {
            playerControl.buffRemoveList.Add(this);
        }
        if (enemyControl != null)
        {
            enemyControl.buffRemoveList.Add(this);
        }
    }

    public override void OnBuffUpdate()
    {
        
    }

    public override void OnBuffRemove()
    {
        if (playerControl != null)
        {
            playerControl.buffList.Remove(this);
        }
        if (enemyControl != null)
        {
            enemyControl.buffList.Remove(this);
        }
    }
}
