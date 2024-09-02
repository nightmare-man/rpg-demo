using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonStateBattle : enemyState
{
    private skeletonEnemy _skeletonEnemy;
    private float moveDir;
    private GameObject player;
    public skeletonStateBattle(enemy __enemy, skeletonEnemy __skeletonEnemy, enemyStateMachine __stateMachine, string __animName) : base(__enemy, __stateMachine, __animName)
    {
        _skeletonEnemy = __skeletonEnemy; 
    }

    public override void enter()
    {
        base.enter();
        player = GameObject.Find("player");
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
            if (_skeletonEnemy.isPlayerDetected().distance< _skeletonEnemy.attackDistance)
            {
                Debug.Log("need attack");
                _skeletonEnemy.zeroVelocity();
                return;
            }
        }
        if (player.transform.position.x > _skeletonEnemy.rb.position.x)
        {
            moveDir = 1.0f;
        }
        else
        {
            moveDir = -1.0f;
        }
        _skeletonEnemy.setVelocity(_skeletonEnemy.moveSpeed * moveDir, _skeletonEnemy.rb.velocity.y);
       
    }
}
