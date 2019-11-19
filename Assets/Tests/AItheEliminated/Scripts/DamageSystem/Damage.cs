using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    //攻击判定所依附的GameObject，是空物体并且只有一个碰撞体
    //public GameObject attachedObject;//其世界是这个脚本挂载的物体
    //该物体所有的碰撞体
    public Collider2D damageCollier;
    //三段攻击每一段的实际计算后的数值应该有另外的计算逻辑根据具体需要得出。
    public float damageOne=0f;
    public float damageTwo=20f;
    public float damageTwo_Delay=0.2f;
    public float damageThree=4f;
    //计时器
    private float timer;
    //本代码用于场景当中的攻击判定
    void Start()
    {
        damageCollier = gameObject.GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //下面分别是三段伤害，进入触发，触发中，离开触发，根据需要来。
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //一段瞬间伤害
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            Player playerState = player.GetComponent<Player>();
            playerState.lifePointValue_Current -= damageOne;
            if (playerState.lifePointValue_Current <= 0)
            {
                if (playerState.lifeCounts_Current > 0)
                {
                    playerState.lifePointValue_Current = playerState.lifePointValue;
                    playerState.lifeCounts_Current -= 1;
                }
                else if (playerState.lifeCounts_Current > 0)
                {
                    playerState.lifePointValue_Current = 0;
                }
            }
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        //二段持续伤害
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            Player playerState = player.GetComponent<Player>();
            timer += Time.deltaTime;
            if (timer > damageTwo_Delay)
            {

                playerState.lifePointValue_Current -= damageTwo;
                if (playerState.lifePointValue_Current <= 0)
                {
                    if (playerState.lifeCounts_Current > 0)
                    {
                        playerState.lifePointValue_Current = playerState.lifePointValue;
                        playerState.lifeCounts_Current -= 1;
                    }
                    else if (playerState.lifeCounts_Current > 0)
                    {
                        playerState.lifePointValue_Current = 0;
                    }
                }
                timer = 0;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //三段瞬间伤害
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            Player playerState = player.GetComponent<Player>();
            playerState.lifePointValue_Current -= damageThree;
            if (playerState.lifePointValue_Current <= 0)
            {
                if (playerState.lifeCounts_Current > 0)
                {
                    playerState.lifePointValue_Current = playerState.lifePointValue;
                    playerState.lifeCounts_Current -= 1;
                }
                else if (playerState.lifeCounts_Current > 0)
                {
                    playerState.lifePointValue_Current = 0;
                }
            }
        }
    }
}
