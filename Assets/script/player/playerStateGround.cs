using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStateGround : playerState
{
    public playerStateGround(playerStateMachine __stateMachine, player __player, string __animName) : base(__stateMachine, __player, __animName)
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
        //跌落
        if (Input.GetKeyDown(KeyCode.J))
        {
            _stateMachine.changeState(_player.playerPrimaryAttack);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            _stateMachine.changeState(_player.playerCounterAttack);
        }
        if (!_player.isGrounded())
        {
            _stateMachine.changeState(_player.playerAir);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
          
            if(hasNoSword())
                _stateMachine.changeState(_player.playerAimSword);
        }
        //明明已经确定了只能在ground state时检测跳跃，为什么还需要加一个isGrounded的碰撞检测？
        //因为有时候任务站在道具上，或者跳到了敌人头上，这个时候，也是groundstate，但是明显不在地面上，不让跳
        if (Input.GetKeyDown(KeyCode.Space) && _player.isGrounded())
        {
            _stateMachine.changeState(_player.playerJump);
        }
        
    }
    private bool hasNoSword()
    {
        if (!_player.sword)
            return true;
        Debug.Log("11");
        _player.sword.GetComponent<swordController>().returnSword();
        return false;
    }
}
