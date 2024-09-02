using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStateMachine
{
    public enemyState currentState { get; private set; }

    public void initialize(enemyState _state)
    {
        currentState = _state;
        currentState.enter();
    }

    public void changeState(enemyState _state) {
        currentState.exit();
        currentState = _state;
        currentState.enter();
    }
}
