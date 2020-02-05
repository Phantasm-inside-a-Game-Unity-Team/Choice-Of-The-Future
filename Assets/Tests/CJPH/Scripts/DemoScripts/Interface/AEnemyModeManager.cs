using UnityEngine;
using System.Collections;

public abstract class AEnemyModeManager : MonoBehaviour
{
    public AMoveMode enemyMoveMode;
    public AAttackMode enemyAttackMode;
    public AHitMode enemyHitMode;
    public float enemySize;
    public abstract void SetMoveMode(AMoveMode moveMode);
    public abstract void SetAttackMode(AAttackMode attackMode);
    public abstract void SetHitMode(AHitMode hitMode);
    public abstract void SetEnemySize(float size);
}
