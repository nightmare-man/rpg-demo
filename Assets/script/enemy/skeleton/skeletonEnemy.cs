using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonEnemy : enemy
{
    #region state
    public skeletonStateIdle idle;
    public skeletonStateMove move;
    public skeletonStateBattle battle;
    public skeletonStateAttack attack;
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
        //��Ȼ��battle״̬����ʵ�ʱ��־���׷����ң���˶������ֻ���move
        battle = new skeletonStateBattle(this, this, stateMachine, "move");
        attack = new skeletonStateAttack(this, this, stateMachine, "attack");
        stateMachine.initialize(idle);
    }

    protected override void Update()
    {
        base.Update();
    }
}
