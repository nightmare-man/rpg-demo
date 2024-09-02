using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonEnemy : enemy
{
    #region state
    public skeletonStateIdle idle;
    public skeletonStateMove move;
    #endregion

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        idle = new skeletonStateIdle(this, this, stateMachine, "idle");
        move = new skeletonStateMove(this, this, stateMachine, "move");
        stateMachine.initialize(idle);
    }

    protected override void Update()
    {
        base.Update();
    }
}
