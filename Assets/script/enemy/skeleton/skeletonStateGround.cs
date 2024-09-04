using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonStateGround : enemyState
{
    protected skeletonEnemy _skeletonEnemy;
    private player player;
    public skeletonStateGround(enemy __enemy,skeletonEnemy __skeletonEnemy, enemyStateMachine __stateMachine, string __animName) : base(__enemy, __stateMachine, __animName)
    {
        _skeletonEnemy = __skeletonEnemy;
    }

    public override void enter()
    {
        base.enter();
        player = playerManager.instance.player;
    }

    public override void exit()
    {
        base.exit();
    }

    public override void update()
    {
        base.update();
        if (_skeletonEnemy.isPlayerDetected()|| Vector2.Distance(player.transform.position,_skeletonEnemy.transform.position)<2)
        {
            _stateMachine.changeState(_skeletonEnemy.battle);
        }
    }
}
