using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class label : MonoBehaviour
{
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

    // 角色朝向
    public bool right = false;
    public bool left = false;
    public bool up = false;
    public bool down = false;

    /*------------label子的各种方法------------ */

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
