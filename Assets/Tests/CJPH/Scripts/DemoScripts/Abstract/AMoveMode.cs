using UnityEngine;
using System.Collections;

public abstract class AMoveMode : MonoBehaviour
{
    public float moveSpeed;             //角色移动速度
    [HideInInspector]
    public bool isCannontMove;          //是否无法移动
    [HideInInspector]
    public bool isCannotSpecialMove;    //是否无法特殊移动
    [HideInInspector]
    public float directionAngle;        //角色朝向与y轴的夹角（角度值，逆时针为正向）
    [HideInInspector]
    public Vector2 characterDirection;  //角色朝向    
    public abstract void Move();                            //移动操作
    public abstract void IsDelayed();                       //硬直时的操作
    public abstract void SetDirection(Vector2 direction);   //设置角色朝向
}
