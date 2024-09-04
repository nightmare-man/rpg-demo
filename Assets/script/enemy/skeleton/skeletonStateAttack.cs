using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonStateAttack : enemyState
{
    private skeletonEnemy _skeletonEnemy;
    public skeletonStateAttack(enemy __enemy, skeletonEnemy __skeletonEnemy, enemyStateMachine __stateMachine, string __animName) : base(__enemy, __stateMachine, __animName)
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
        _skeletonEnemy.lastAttackTime = Time.time;
    }

    public override void update()
    {
        base.update();
        _skeletonEnemy.zeroVelocity();
        if (_animTrigger)
        {
            _stateMachine.changeState(_skeletonEnemy.battle);
        }
    }
}
