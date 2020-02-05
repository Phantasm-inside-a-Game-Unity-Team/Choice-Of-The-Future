using UnityEngine;
using System.Collections;

public abstract class AAttackMode : MonoBehaviour
{
    [HideInInspector]
    public bool cannotAttack;
    public abstract void Attack();
    public abstract void PowerUp(int power);
}
