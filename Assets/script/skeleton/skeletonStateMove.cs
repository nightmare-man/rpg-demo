using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonStateMove : enemyState
{
    //这个地方为什么要加一个子类变量，并要构造函数传入?
    //如果没有这个变量，就只能访问基类的成员，无法访问子类特有的state，就无法切换
    //比如idle和move都是skeleton的 基类enemy没有，两个状态之间切换的时候，就需要子类实例
    private skeletonEnemy _skeletonEnemy;

    //为什么这个地方比父类构造函数多一个参数，目的是用这个
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
