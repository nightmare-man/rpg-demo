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
        //直接dash到一堵墙上
        //这也就意味着不能在墙上dash，不然一直循环判定了，已经在墙上了，dash就立刻变成wallslide
        //因此在dash检测中，要排除面对墙上这个状态
        if (!_player.isGrounded() && _player.isWallDetected())
        {
            _stateMachine.changeState(_player.playerWallSlide);
            return;
        }
        _player.setVelocity(_player.dashDir * _player.dashSpeed, 0);//保证能悬停
        if (stateTime < 0)
        {
            
            _stateMachine.changeState(_player.playerIdle);
        }
    }
}
