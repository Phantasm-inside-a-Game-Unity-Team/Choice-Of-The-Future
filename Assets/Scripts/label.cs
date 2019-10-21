using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class label : MonoBehaviour
{
    // 需要绑定的动画器
    public Animator animator;

/*------------初始化label子的属性------------ */

    // 角色的经验,具体说明见开发文档
    // 总经验
    public int exp = 0;
    // 累计经验
    private int Exp = 0;
    // 当前经验
    private int _exp = 0; 

    // 角色的等级
    public int level = 1;

    // 角色的血量
    public int HP = 100;
    // 当前血量
    public int _HP = 100;

    // 角色的MP
    public int MP = 100;
    // 角色当前的MP
    public int _MP = 100;

    // 角色的TP
    public int TP = 100;
    public int _TP = 100;

    // 角色的攻击力
    public int ATK = 50;
    // 角色的当前攻击力
    public int _ATK = 50;
    
    // 角色的暴击概率
    public int crit = 0;


    // 角色移速
    public float speed = 5.0f;

    // 角色朝向
    public bool right = false;
    public bool left = false;
    public bool up = false;
    public bool down = false;

    // 人物移动键位设置
    public KeyCode moveRight = KeyCode.D;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;

    /*------------label子的各种方法------------ */

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        MoveCharacter();
    }

    //控制人物行走的方法 
    void MoveCharacter() {
        // 判断按键是否按下的标志
        bool buttonIsPressed = false;
        // 按下D键，角色向右行走
        if(Input.GetKey(moveRight)) {
            // 调整动画器内的变量，使得动画状态变成WalkRight,注意顺序不能颠倒
            animator.SetBool("walkStop",false);
            animator.SetBool("walkContinue",true);
            animator.SetBool("walkLeft", false);
            animator.SetBool("walkUp", false);
            animator.SetBool("walkDown", false);
            animator.SetBool("walkRight", true);
            // 调整角色的朝向
            down = false;
            left = false;
            up = false;
            right = true;
            // 按键按下，标志置为true
            buttonIsPressed = true;
            // 角色移动
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        // 按下A键，角色向左行走
        if (Input.GetKey(moveLeft)) {
            // 调整动画器内的变量，使得动画状态变成WalkLeft，注意顺序不能颠倒
            animator.SetBool("walkStop",false);
            animator.SetBool("walkContinue",true);
            animator.SetBool("walkStop",false);
            animator.SetBool("walkRight", false);
            animator.SetBool("walkUp", false);
            animator.SetBool("walkDown", false);
            animator.SetBool("walkLeft", true);
            // 调整角色的朝向
            down = false;
            left = true;
            up = false;
            right = false;
            // 按键按下，标志置为true
            buttonIsPressed = true;
            // 角色移动
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        // 按下W键，角色向上行走
        if(Input.GetKey(moveUp)) {
            // 调整动画器内的变量，使得动画状态变成WalkUp，注意顺序不能颠倒
            animator.SetBool("walkStop",false);
            animator.SetBool("walkContinue",true);
            animator.SetBool("walkLeft", false);
            animator.SetBool("walkUp" ,true);
            animator.SetBool("walkDown", false);
            animator.SetBool("walkRight", false);
            // 调整角色的朝向
            down = false;
            left = false;
            up = true;
            right = false;
            // 按键按下，标志置为true
            buttonIsPressed = true;
            // 角色移动
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        // 按下S键，角色向下行走
        if(Input.GetKey(moveDown)) {
            // 调整动画器内的变量，使得动画状态变成WalkDown，注意顺序不能颠倒
            animator.SetBool("walkStop",false);
            animator.SetBool("walkContinue",true);
            animator.SetBool("walkLeft", false);
            animator.SetBool("walkUp", false);
            animator.SetBool("walkDown", true);
            animator.SetBool("walkRight", false);
            // 调整角色的朝向
            down = true;
            left = false;
            up = false;
            right = false;
            // 按键按下，标志置为true
            buttonIsPressed = true;
            // 角色移动
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        // 如果没有按键按下，则进入停止状态
        if(!buttonIsPressed) {
            // 调整动画器内的变量，使得动画状态变成WalkStop,注意顺序不能变
            animator.SetBool("walkContinue",false);
            animator.SetBool("walkLeft", false);
            animator.SetBool("walkUp", false);
            animator.SetBool("walkDown", false);
            animator.SetBool("walkRight", false);
            animator.SetBool("walkStop",true);
        }
    }
}
