using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStateWallJump : playerState
{
    public playerStateWallJump(playerStateMachine __stateMachine, player __player, string __animName) : base(__stateMachine, __player, __animName)
    {
    }

    public override void enter()
    {
        base.enter();
        stateTime = 1.0f;
        _player.rb.velocity = new Vector2(-5 * _player.faceDir, _player.jumpForce);
    }

    public override void exit()
    {
        base.exit();
    }

    public override void update()
    {
        base.update();
        //如果高度比较矮，不到1s就着地了，需要从walljump改成idle
        
        if (_player.rb.velocity.y < 0)
        {
            _stateMachine.changeState(_player.playerAir);
        }

    }
}
