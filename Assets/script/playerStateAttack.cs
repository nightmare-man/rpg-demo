using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStateAttack : playerState
{
    private float lastAttackTime;
    private float comboWindow = 2.0f;
    private int comboCounter = 0;
    public playerStateAttack(playerStateMachine __stateMachine, player __player, string __animName) : base(__stateMachine, __player, __animName)
    {
    }

    public override void enter()
    {
        base.enter();
        
        if (comboCounter > 2 || Time.time - lastAttackTime > comboWindow)
            comboCounter = 0;
        _player.anim.SetInteger("comboCounter", comboCounter);
        _player.setVelocity(_player.faceDir * _player.attackMovement[comboCounter], _player.rb.velocity.y);
        stateTime = 0.1f;

        
    }

    public override void exit()
    {
        base.exit();
        comboCounter++;
        lastAttackTime = Time.time;
        _player.StartCoroutine("busyFor", 0.1f);
    }

    public override void update()
    {
        base.update();
        if (stateTime < 0)
        {
            _player.zeroVelocity();
        }
        if (!trigger)
        {
            _stateMachine.changeState(_player.playerIdle);
        }
    }
}
