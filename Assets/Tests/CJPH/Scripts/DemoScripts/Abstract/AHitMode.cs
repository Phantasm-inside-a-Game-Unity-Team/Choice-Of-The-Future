using UnityEngine;
using System.Collections;

public abstract class AHitMode : MonoBehaviour
{
    public abstract void Hit();
    public abstract void IsHit(int atkPoint, int effect);
}
