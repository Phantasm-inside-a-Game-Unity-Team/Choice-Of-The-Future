using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModeManager : APlayerModeManager
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMoveMode.Move();
        playerAttackMode.Attack();
        playerHitMode.Hit();
    }

    public override void SetMoveMode(AMoveMode moveMode)
    {
        playerMoveMode = moveMode;
    }

    public override void SetAttackMode(AAttackMode attackMode)
    {
        playerAttackMode = attackMode;
    }

    public override void SetPlayerSize(float size)
    {
        playerSize = size;
    }

    public override void SetHitMode(AHitMode hitMode)
    {
        playerHitMode = hitMode;
    }
}
