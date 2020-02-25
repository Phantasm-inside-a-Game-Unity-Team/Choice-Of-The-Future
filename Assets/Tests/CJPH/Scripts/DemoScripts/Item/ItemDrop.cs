using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public AItem item;                  //物品
    public float distance;              //物品落地距离
    public float hight;                 //物品抛物线高度
    public float velocity;              //物品掉落速度
    float a;                            //抛物线方程二次项系数
    float x;                            //抛物线方程自变量x
    float y;                            //抛物线方程应变量y
    float timeSinceDrop;                //物品掉落后计时
    Vector3 startPosition;              //物品掉落开始位置
    float startTime;                    //物品掉落开始时间
    Vector3 direction;                  //掉落方向

    // Start is called before the first frame update
    void Start()
    {
        distance -= distance * Random.value * 0.5f;
        a = -4 * hight * velocity * velocity / distance / distance;
        startPosition = transform.position;
        startTime = Time.timeSinceLevelLoad;
        direction = Random.insideUnitCircle;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceDrop = Time.time - startTime;
        if (timeSinceDrop < distance / velocity)
        {
            x = timeSinceDrop * velocity;
            y = a * timeSinceDrop * timeSinceDrop - a * (distance / velocity) * timeSinceDrop;
            transform.position = direction.normalized * x + Vector3.up * y + startPosition; //抛物线弹幕显示位置
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (timeSinceDrop > distance / velocity && collider.gameObject.layer == 10)
        {
            item.ItemEffect(collider.gameObject);
            Destroy(gameObject);
        }
    }

}
