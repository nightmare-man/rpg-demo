using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStateDash : playerState
{
    public playerStateDash(playerStateMachine __stateMachine, player __player, string __animName) : base(__stateMachine, __player, __animName)
    {
    }

    public override void enter()
    {
        base.enter();
        stateTime = _player.dashTime;
       
    }

    public override void exit()
    {
        base.exit();
        _player.setVelocity(0, _player.rb.velocity.y);
    }

    public override void update()
    {
        base.update();
        _player.setVelocity(_player.dashDir * _player.dashSpeed, 0);//±£Ö¤ÄÜÐüÍ£
        if (stateTime < 0)
        {
            
            _stateMachine.changeState(_player.playerIdle);
        }
    }
}
