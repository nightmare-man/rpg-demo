using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyState 
{

    protected enemy _enemyBase;
    protected enemyStateMachine _stateMachine;
    protected string _animName;
    protected bool _animTrigger { get; private set; }
    protected float stateTime;
    public enemyState(enemy __enemy, enemyStateMachine __stateMachine, string __animName)
    {
        _enemyBase = __enemy;
        _stateMachine = __stateMachine;
        _animName = __animName;
    }

    public virtual void enter()
    {
        _animTrigger = false;
        _enemyBase.anim.SetBool(_animName, true);
    }

    public virtual void exit()
    {
        _enemyBase.anim.SetBool(_animName, false);
    }

    public virtual void update()
    {
        stateTime -= Time.deltaTime;
    }
    public void animFinishTrigger()
    {
        _animTrigger = true;
    }
}
