using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonStateStunned : enemyState
{
    private skeletonEnemy _skeletonEnemy;
    public skeletonStateStunned(enemy __enemy, skeletonEnemy __skeletonEnemy, enemyStateMachine __stateMachine, string __animName) : base(__enemy, __stateMachine, __animName)
    {
        _skeletonEnemy = __skeletonEnemy;
    }

    public override void enter()
    {
        base.enter();
        stateTime = _skeletonEnemy.stunnedDuration;
        _skeletonEnemy.rb.velocity = new Vector2(-_skeletonEnemy.faceDir * _skeletonEnemy.stunnedDirection.x, _skeletonEnemy.stunnedDirection.y);
        _skeletonEnemy.ef.InvokeRepeating("blinkColor", 0, 0.2f);
    }

    public override void exit()
    {
        base.exit();
        _skeletonEnemy.ef.Invoke("cancelBlink", 0);
    }

    public override void update()
    {
        base.update();
        if (stateTime < 0)
        {
            _stateMachine.changeState(_skeletonEnemy.idle);
        }
    }
}
