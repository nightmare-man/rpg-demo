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
                    //�ȸ�ʱ�䲥�ŷ����ɹ���������ֹ�˳�����״̬
                    stateTime = 3.0f;
                    _player.anim.SetBool("playerCounterAttackSuccessful", true);
                    
                    //���￴��Ҫ�����ֻ����һ���˵ģ���break
                    //�����break���������ʱ���ڷ������ڵĹ��ﶼ���������Ρ�
                }
            }
        }
    }
}
   

