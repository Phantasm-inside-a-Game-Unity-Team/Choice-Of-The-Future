using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    public float moveSpeed;
    Animator playerAnimator;
    float inputX;
    float inputY;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetFloat("axisX", 0);
        playerAnimator.SetFloat("axisY", 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        if (inputX == 0 && inputY == 0)
        {
            playerAnimator.speed = 0;
            int animationHash = playerAnimator.GetCurrentAnimatorStateInfo(0).fullPathHash;
            playerAnimator.Play(animationHash, 0, 0);
        }
        else
        {
            playerAnimator.SetFloat("axisX", inputX);
            playerAnimator.SetFloat("axisY", inputY);
            playerAnimator.speed = 1;
            transform.Translate(inputX * Time.deltaTime*moveSpeed, inputY * Time.deltaTime*moveSpeed, 0);
        }
    }
}
