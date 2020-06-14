using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactAttack : MonoBehaviour
{
    public float attackPoint;
    public int effect;                  //攻击效果
    public BuffType thisBuffType;       //弹幕初始自带的buff类型
    public List<float> thisBuffPara;    //弹幕初始自带的buff参数
    public List<ABuff> buffList = new List<ABuff>();        //弹幕上所有会触发的buff效果列表

    private bool isTriggerEnter;
    private PlayerControl playerControl;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggerEnter)
        {
            if (buffList.Count == 0)
            {
                buffList.Add(BuffGroup.CreateBuff(playerControl, thisBuffType, thisBuffPara));
            }
            playerControl.playerHitMode.BeHit(attackPoint, buffList, effect);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 10)
        {
            playerControl = collider.gameObject.GetComponent<PlayerControl>();
            isTriggerEnter = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 10)
        {
            isTriggerEnter = false;
        }
    }
}
