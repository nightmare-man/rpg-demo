using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonStateMove : skeletonStateGround
{
    public skeletonStateMove(enemy __enemy, skeletonEnemy __skeletonEnemy, enemyStateMachine __stateMachine, string __animName) : base(__enemy, __skeletonEnemy, __stateMachine, __animName)
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
        _skeletonEnemy.setVelocity(_skeletonEnemy.moveSpeed * _skeletonEnemy.faceDir, _skeletonEnemy.rb.velocity.y);
        if(_skeletonEnemy.isWallDetected() || !_skeletonEnemy.isGrounded())
        {
            _stateMachine.changeState(_skeletonEnemy.idle);
            _skeletonEnemy.flip();
        }
    }
}
