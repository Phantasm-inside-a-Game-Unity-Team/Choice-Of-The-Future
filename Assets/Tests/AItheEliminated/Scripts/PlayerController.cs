using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    /*该脚本应该主要有两个部分，一为玩家对象的控制，二为玩家对象数值的管理
     * （会代替现有的PlayerWork脚本）
     * 
     */


    //当前控制的角色
    public Player mainPlayer;
    //当前副手角色
    public Player subPlayer;
    //是否有互动可触发
    public bool ifInteractable;
    //目前的目标NPC
    public GameObject aimNPC;

    public float moveSpeed;
    public Animator playerAnimator;
    public Rigidbody2D rb;
    float inputX;
    float inputY;
    float inputInteraction;
    void Start()
    {

    }

    private void Update()
    {
        MoveCharacter();
        CharactorInteract();
    }
    //角色移动
    void MoveCharacter()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        bool isIdle = (inputX == 0 && inputY == 0);
        playerAnimator.SetBool("walkContinue", !isIdle);
        playerAnimator.SetBool("walkStop", isIdle);
        if (!isIdle)
        {
            playerAnimator.SetFloat("axisX", inputX);
            playerAnimator.SetFloat("axisY", inputY);
        }
        rb.velocity = new Vector2(inputX * moveSpeed, inputY * moveSpeed);
    }
    //角色互动检测
    void CharactorInteract()
    {

        inputInteraction = Input.GetAxisRaw("Interact");

        Ray2D ray = new Ray2D(transform.position, rb.velocity.normalized);
        RaycastHit2D[] infos = Physics2D.RaycastAll(ray.origin, ray.direction, 10f);
        Debug.DrawRay(ray.origin,ray.direction,Color.blue);
        foreach (RaycastHit2D info in infos)
        {
            if (info.collider != null)
            {
                if (info.transform.gameObject.tag == "NPC" && inputInteraction != 0)
                {
                    aimNPC = info.transform.gameObject;
                    aimNPC.GetComponent<DialogBox>().OpenDialogBox();
                    Debug.Log("对话！");
                }
            }
            else
            {
                Debug.Log("没有碰撞任何对象");
            }
        }
        Debug.DrawRay(gameObject.transform.position, ray.direction, Color.blue);
    }
        
    


}
