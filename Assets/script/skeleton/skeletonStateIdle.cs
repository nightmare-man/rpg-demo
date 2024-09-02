using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonStateIdle : enemyState
{
    private skeletonEnemy _skeletonEnemy;
    public skeletonStateIdle(enemy __enemy, skeletonEnemy __skeletonEnemy,enemyStateMachine __stateMachine, string __animName) : base(__enemy, __stateMachine, __animName)
    {
        _enemyBase = __enemy;
        _skeletonEnemy = __skeletonEnemy;
        _stateMachine = __stateMachine;
        _animName = __animName;

    }

    public override void enter()
    {
        base.enter();
        stateTime = _enemyBase.idleTime;
        _skeletonEnemy.zeroVelocity();
    }

    public override void exit()
    {
        base.exit();
    }

    public override void update()
    {
        base.update();
        if (stateTime < 0)
        {
            _stateMachine.changeState(_skeletonEnemy.move);
        }
    }
}
