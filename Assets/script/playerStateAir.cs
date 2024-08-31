using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStateAir : playerState
{
    public playerStateAir(playerStateMachine __stateMachine, player __player, string __animName) : base(__stateMachine, __player, __animName)
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
        if (_player.rb.velocity.y == 0)
        {
            _stateMachine.changeState(_player.playerIdle);
        }
    }
}
