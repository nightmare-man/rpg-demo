using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerState 
{
    protected playerStateMachine _stateMachine { get; private set; }
    protected player _player { get; private set; }
    public string _animName { get; private set; }
    protected float xInput { get; private set; }
    protected float yInput { get; private set; }
    protected float stateTime;
    protected bool trigger { get; private set; }
    public playerState(playerStateMachine __stateMachine, player __player, string __animName)
    {
        _stateMachine = __stateMachine;
        _player = __player;
        _animName = __animName;
    }

    public virtual void enter()
    {
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
