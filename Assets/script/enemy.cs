using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : entity
{
    [Header("move info")]
    [SerializeField] public float moveSpeed;
    [SerializeField] public float idleTime;

    [Header("battle info")]
    public LayerMask whatIsPlayer;
    public float attackDistance;

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
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;//»»¸öÑÕÉ«
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance, transform.position.y));
    }
    public virtual RaycastHit2D isPlayerDetected() => Physics2D.Raycast(transform.position, Vector2.right * faceDir, 50, whatIsPlayer);
}
