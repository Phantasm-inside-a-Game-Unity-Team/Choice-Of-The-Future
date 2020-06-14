using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AHitMode : MonoBehaviour
{
    public abstract void Hit();
    public abstract void BeHit(float atkPoint, List<ABuff> buffList, int effect);
}
