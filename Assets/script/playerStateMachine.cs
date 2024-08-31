using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStateMachine 
{
    public playerState currentState { get; private set; }
    public playerStateMachine()
    {

    }
    public void initialize(playerState initializeState)
    {
        currentState = initializeState;
        currentState.enter();
    }
    public void changeState(playerState newState)
    {
        currentState.exit();
        currentState = newState;
        currentState.enter();
    }
}
