using UnityEngine;
using System.Collections;

public abstract class AMoveMode : MonoBehaviour
{
    public bool cannontMove;
    /// <summary>
    /// 角色移动速度
    /// </summary>
    public float moveSpeed;
    [HideInInspector]
    /// <summary>
    /// 角色朝向与y轴的夹角（弧度，逆时针为正向）
    /// </summary>
    public float directionAngle;
    public abstract void Move();
    public abstract void IsDelayed();
}
