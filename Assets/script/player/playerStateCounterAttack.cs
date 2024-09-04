using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStateCounterAttack : playerState
{
    public playerStateCounterAttack(playerStateMachine __stateMachine, player __player, string __animName) : base(__stateMachine, __player, __animName)
    {
    }

    public override void enter()
    {
        base.enter();
        stateTime = _player.counterAttackDuration;
        _player.anim.SetBool("playerCounterAttackSuccessful", false);
    }

    public override void exit()
    {
        base.exit();
    }

    public override void update()
    {
        base.update();
        if (stateTime < 0|| trigger)
        {
           // _player.anim.SetBool("playerCounterAttackSuccessful", false);
            _stateMachine.changeState(_player.playerIdle);
            return;
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_player.attackCheckPoint.transform.position, _player.attackCheckDistance);
        foreach(var hit in colliders)
        {
            if (hit.GetComponent<enemy>() != null)
            {
                if (hit.GetComponent<enemy>().attemptTpStunned())
                {
                    //先给时间播放反击成功动画，防止退出反击状态
                    stateTime = 3.0f;
                    _player.anim.SetBool("playerCounterAttackSuccessful", true);
                    
                    //这里看需要，如果只反击一个人的，就break
                    //如果不break，所有这个时候在反击窗口的怪物都被反击击晕。
                }
            }
        }
    }
}
   

