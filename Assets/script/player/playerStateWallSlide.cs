using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStateWallSlide : playerState
{
    public playerStateWallSlide(playerStateMachine __stateMachine, player __player, string __animName) : base(__stateMachine, __player, __animName)
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _stateMachine.changeState(_player.playerWallJump);
            return;
        }
        if (xInput != 0)
        {
            if (xInput != _player.faceDir)
            {
                _stateMachine.changeState(_player.playerIdle);//这里用idle，如果还在
                //空中，自己会转成air的
            }
        }
        if (yInput >= 0)
        {
            //这个地方是循环*0.7 目的是降低速度，不用担心降低到0，有重力加速度
            _player.rb.velocity = new Vector2(0, _player.rb.velocity.y * 0.8f);
        }
        
        if (_player.isGrounded())
        {
            _stateMachine.changeState(_player.playerIdle);
        }
    }
}
