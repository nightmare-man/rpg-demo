using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonStateIdle : skeletonStateGround
{
    public skeletonStateIdle(enemy __enemy, skeletonEnemy __skeletonEnemy, enemyStateMachine __stateMachine, string __animName) : base(__enemy, __skeletonEnemy, __stateMachine, __animName)
    {
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
