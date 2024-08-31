using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerState 
{
    protected playerStateMachine _stateMachine { get; private set; }
    protected player _player { get; private set; }
    private string _animName;
    protected float xInput;
    

    public playerState(playerStateMachine __stateMachine, player __player, string __animName)
    {
        _stateMachine = __stateMachine;
        _player = __player;
        _animName = __animName;
    }

    public virtual void enter()
    {
        _player.anim.SetBool(_animName, true);
        
    }
    public virtual void exit()
    {
        _player.anim.SetBool(_animName, false);
       
    }

    public virtual void update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        _player.anim.SetFloat("yVelocity", _player.rb.velocity.y);
    }
}
