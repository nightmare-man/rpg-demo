using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : entity
{
    [Header("move info")]
    [SerializeField] public float moveSpeed;
    [SerializeField] public float idleTime;

    public enemyStateMachine stateMachine;
    protected override void Awake()
    {
        stateMachine = new enemyStateMachine();
        base.Awake();
    }

    protected override void Start()
    {
       
        base.Start();
        
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.update();
    }
}
