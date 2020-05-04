﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuffType
{
    Poison,
    Stun,
    Shield,
    Frozen,
    Blank
}

public class BuffGroup
{
    public static ABuff CreateBuff(PlayerControl playerControl, BuffType buffType, List<float> buffParaList)
    {
        switch (buffType)
        {
            case BuffType.Poison:
                return new BuffPoison(playerControl, buffParaList);
            case BuffType.Stun:
                return new BuffStun(playerControl, buffParaList);
            case BuffType.Shield:
                return new BuffShield(playerControl, buffParaList);
            case BuffType.Frozen:
                return new BuffFrozen(playerControl, buffParaList);
            case BuffType.Blank:
                return new BuffBlank(playerControl);
            default:
                Debug.LogWarning("no buffType is found");
                return new BuffBlank(playerControl);
        }
    }

    public static ABuff CreateBuff(EnemyControl enemyControl, BuffType buffType, List<float> buffParaList)
    {
        switch (buffType)
        {
            case BuffType.Poison:
                return new BuffPoison(enemyControl, buffParaList);
            case BuffType.Stun:
                return new BuffStun(enemyControl, buffParaList);
            case BuffType.Shield:
                return new BuffShield(enemyControl, buffParaList);
            case BuffType.Frozen:
                return new BuffFrozen(enemyControl, buffParaList);
            case BuffType.Blank:
                return new BuffBlank(enemyControl);
            default:
                Debug.LogWarning("no buffType is found");
                return new BuffBlank(enemyControl);
        }
    }
}
