using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        Debug.Log("battle");
    }

    public override void exit()
    {
        base.exit();
        Debug.Log("exit battle");
    }

    public override void update()
    {
        base.update();
        if (_skeletonEnemy.isPlayerDetected())
        {
            //如果一直能检测到玩家，就一直重置追逐时间
            stateTime = _skeletonEnemy.continusbattleTime;
            if (_skeletonEnemy.isPlayerDetected().distance< _skeletonEnemy.attackDistance)
            {
                if (canAttack())
                {
                    
                    _stateMachine.changeState(_skeletonEnemy.attack);
                   
                }
                return;
            }
        }
        else
        {
            if (stateTime < 0 || Vector2.Distance(_skeletonEnemy.transform.position,player.transform.position)>_skeletonEnemy.continusbattleDistance)
            {
                _stateMachine.changeState(_skeletonEnemy.idle);
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
    private bool canAttack()
    {
        if (Time.time - _skeletonEnemy.lastAttackTime > _skeletonEnemy.attackCoolDown)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
