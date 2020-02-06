using UnityEngine;
using System.Collections;

public abstract class AAttackMode : MonoBehaviour
{
    [HideInInspector]
    public bool isCannotAttack;
    public abstract void Attack();
    public abstract void PowerUp(int power);
}
