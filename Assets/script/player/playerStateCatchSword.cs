using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStateCatchSword : playerState
{
    public playerStateCatchSword(playerStateMachine __stateMachine, player __player, string __animName) : base(__stateMachine, __player, __animName)
    {
    }

    public override void enter()
    {
        base.enter();
        Transform sword = _player.sword.transform;
        if (sword.position.x > _player.transform.position.x && !_player.faceRight)
            _player.flip();
        else if (sword.position.x < _player.transform.position.x && _player.faceRight)
            _player.flip();
    }

    public override void exit()
    {
        base.exit();
    }

    public override void update()
    {
        base.update();
        if ( trigger)
        {
            _stateMachine.changeState(_player.playerIdle);
        }
    }
}
