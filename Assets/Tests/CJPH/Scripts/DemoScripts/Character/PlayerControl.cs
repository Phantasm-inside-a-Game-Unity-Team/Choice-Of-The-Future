using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public AMoveMode playerMoveMode;
    public AAttackMode playerAttackMode;
    public AHitMode playerHitMode;
    public bool isDead;

    // Use this for initialization
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerMoveMode.Move();
        playerAttackMode.Attack();
        playerHitMode.Hit();
    }
    void IsAlive()
    {

    }

}
