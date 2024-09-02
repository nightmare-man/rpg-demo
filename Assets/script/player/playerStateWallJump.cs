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
        if (stateTime < 0) {
            _stateMachine.changeState(_player.playerAir);
        }

        //����߶ȱȽϰ�������1s���ŵ��ˣ���Ҫ��walljump�ĳ�idle
        if (_player.isGrounded())
        {
        
            _stateMachine.changeState(_player.playerIdle);
        }
    }
}
