using UnityEngine;
using System.Collections;

public abstract class AMoveMode : MonoBehaviour
{
    public bool isCannontMove;
    public float moveSpeed;         //角色移动速度
    [HideInInspector]
    public float directionAngle;    //角色朝向与y轴的夹角（弧度，逆时针为正向）
    public abstract void Move();
    public abstract void IsDelayed();
}
