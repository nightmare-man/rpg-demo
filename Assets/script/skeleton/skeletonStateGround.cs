using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonStateGround : enemyState
{
    protected skeletonEnemy _skeletonEnemy;
    public skeletonStateGround(enemy __enemy,skeletonEnemy __skeletonEnemy, enemyStateMachine __stateMachine, string __animName) : base(__enemy, __stateMachine, __animName)
    {
        _skeletonEnemy = __skeletonEnemy;
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
        if (_skeletonEnemy.isPlayerDetected())
        {
            _stateMachine.changeState(_skeletonEnemy.battle);
        }
    }
}
