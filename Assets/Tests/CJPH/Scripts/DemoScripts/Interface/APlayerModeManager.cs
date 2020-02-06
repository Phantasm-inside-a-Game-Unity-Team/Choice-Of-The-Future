using UnityEngine;
using System.Collections;

public abstract class APlayerModeManager : MonoBehaviour
{
    public AMoveMode playerMoveMode;
    public AAttackMode playerAttackMode;
    public AHitMode playerHitMode;
    public float playerSize;
    public abstract void SetMoveMode(AMoveMode moveMode);
    public abstract void SetAttackMode(AAttackMode attackMode);
    public abstract void SetHitMode(AHitMode hitMode);
    public abstract void SetPlayerSize(float size);
}
