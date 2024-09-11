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
        //����
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
        //�����Ѿ�ȷ����ֻ����ground stateʱ�����Ծ��Ϊʲô����Ҫ��һ��isGrounded����ײ��⣿
        //��Ϊ��ʱ������վ�ڵ����ϣ����������˵���ͷ�ϣ����ʱ��Ҳ��groundstate���������Բ��ڵ����ϣ�������
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
