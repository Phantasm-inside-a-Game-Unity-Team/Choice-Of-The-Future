using UnityEngine;
using System.Collections;

public interface IMoveMode
{
    float directionAngle { get;}
    void Move();
    void IsDelayed();
}
