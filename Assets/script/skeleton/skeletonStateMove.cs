using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonStateMove : enemyState
{
    //����ط�ΪʲôҪ��һ�������������Ҫ���캯������?
    //���û�������������ֻ�ܷ��ʻ���ĳ�Ա���޷������������е�state�����޷��л�
    //����idle��move����skeleton�� ����enemyû�У�����״̬֮���л���ʱ�򣬾���Ҫ����ʵ��
    private skeletonEnemy _skeletonEnemy;

    //Ϊʲô����ط��ȸ��๹�캯����һ��������Ŀ���������
    public skeletonStateMove(enemy __enemy, skeletonEnemy __skeletonEnemy, enemyStateMachine __stateMachine, string __animName) : base(__enemy, __stateMachine, __animName)
    {
        _enemyBase = __enemy;
        _skeletonEnemy = __skeletonEnemy;
        _stateMachine = __stateMachine;
        _animName = __animName;

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
        _skeletonEnemy.setVelocity(_skeletonEnemy.moveSpeed * _skeletonEnemy.faceDir, _skeletonEnemy.rb.velocity.y);
        if(_skeletonEnemy.isWallDetected() || !_skeletonEnemy.isGrounded())
        {
            _stateMachine.changeState(_skeletonEnemy.idle);
            _skeletonEnemy.flip();
        }
    }
}
