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
    public skeletonStateStunned stunned;
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
        stunned = new skeletonStateStunned(this, this, stateMachine, "stunned");
        stateMachine.initialize(idle);
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.P))
        {
            stateMachine.changeState(stunned);
        }
    }
    /// <summary>
    /// ����Ƿ��ܹ�stunned,�ܵĻ��ͽ���stunned״̬
    /// </summary>
    /// <returns></returns>
    public override bool attemptTpStunned()
    {
        if (base.attemptTpStunned())
        {
            stateMachine.changeState(stunned);
            return true;
        }
        return false;
    }
}
