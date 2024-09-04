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
                _stateMachine.changeState(_player.playerIdle);//������idle���������
                //���У��Լ���ת��air��
            }
        }
        if (yInput >= 0)
        {
            //����ط���ѭ��*0.7 Ŀ���ǽ����ٶȣ����õ��Ľ��͵�0�����������ٶ�
            _player.rb.velocity = new Vector2(0, _player.rb.velocity.y * 0.8f);
        }
        
        if (_player.isGrounded())
        {
            _stateMachine.changeState(_player.playerIdle);
        }
    }
}
