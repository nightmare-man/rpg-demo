using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStateAimSword : playerState
{
    public playerStateAimSword(playerStateMachine __stateMachine, player __player, string __animName) : base(__stateMachine, __player, __animName)
    {
    }

    public override void enter()
    {
        base.enter();
    }

    public override void exit()
    {
        base.exit();
    }

    public override void update()
    {
        base.update();
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            _stateMachine.changeState(_player.playerIdle);
        }
    }
}
