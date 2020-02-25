using UnityEngine;
using System.Collections;

public abstract class AHitMode : MonoBehaviour
{
    public abstract void Hit();
    public abstract void BeHit(float atkPoint, int effect);
}
