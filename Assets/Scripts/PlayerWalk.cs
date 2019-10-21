using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    public float moveSpeed;
    public Animator playerAnimator;
    float inputX;
    float inputY;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    // Update is called once per frame
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
            transform.Translate(inputX * Time.deltaTime*moveSpeed, inputY * Time.deltaTime*moveSpeed, 0);
        }
    }
}
