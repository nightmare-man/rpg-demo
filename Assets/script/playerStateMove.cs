using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStateMove : playerStateGround
{
    public playerStateMove(playerStateMachine __stateMachine, player __player, string __animName) : base(__stateMachine, __player, __animName)
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
        _player.setVelocity(xInput*_player.moveSpeed, _player.rb.velocity.y);
        if (xInput == 0)
        {
            _stateMachine.changeState(_player.playerIdle);
        }
    }
}
