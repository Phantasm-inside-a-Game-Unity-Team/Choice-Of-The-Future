using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderControl : MonoBehaviour
{
    public GameObject colliderActive;   //激活的碰撞体
    public GameObject colliderDeactive; //移除的碰撞体
    public Renderer render;             //需要调整显示顺序的物体的renderer
    public int orderInLayer;            //显示顺序，对应renderer组件里的Order in Layer
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //角色碰到触发位置后，更改对应的碰撞体和物体显示顺序
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("trigenter");

            colliderActive.SetActive(true);
            colliderDeactive.SetActive(false);
            render.sortingOrder = orderInLayer;
        }
    }
}
