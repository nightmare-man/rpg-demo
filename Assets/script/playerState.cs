using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerState 
{
    protected playerStateMachine _stateMachine { get; private set; }
    protected player _player { get; private set; }
    private string _animName;
    protected float xInput;
    protected float yInput;
    protected float stateTime;
    protected bool trigger;
    public playerState(playerStateMachine __stateMachine, player __player, string __animName)
    {
        _stateMachine = __stateMachine;
        _player = __player;
        _animName = __animName;
    }

    public virtual void enter()
    {
        Debug.Log("enter " + _animName);
        _player.anim.SetBool(_animName, true);
        trigger = true;
        
    }
    public virtual void exit()
    {
        _player.anim.SetBool(_animName, false);
       
    }

    public virtual void update()
    {
        stateTime -= Time.deltaTime;
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        _player.anim.SetFloat("yVelocity", _player.rb.velocity.y);
    }
    public virtual void animatorFinishTrigger()
    {
        trigger = false;
    }
}
