using UnityEngine;
using System.Collections;

public interface IHitMode
{
    void Hit();
    void IsHit(int atkPoint,int effect);
}
