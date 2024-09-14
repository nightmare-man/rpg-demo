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
        skillManager.instance.swordSkill.setDotsActivate(true);
    }

    public override void exit()
    {
        base.exit();
        skillManager.instance.swordSkill.setDotsActivate(false);
    }

    public override void update()
    {
       
        base.update();
        
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            _stateMachine.changeState(_player.playerIdle);
        }

        float mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        if (mouseX>_player.transform.position.x && !_player.faceRight)
        {
            _player.flip();
        }else if (mouseX < _player.transform.position.x && _player.faceRight)
        {
            _player.flip();
        }
    }
}
