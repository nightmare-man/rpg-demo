using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : entity
{
    [Header("move info")]
    [SerializeField] public float moveSpeed;
    [SerializeField] public float idleTime;

    [Header("stunned info")]
    public float stunnedDuration;
    public Vector2 stunnedDirection;
    private bool _canBeStunned;
    [SerializeField] private GameObject counterAttackWindow;

    [Header("battle info")]
    public LayerMask whatIsPlayer;
    public float attackDistance;
    public float attackCoolDown;
    public float continusbattleTime;
    public float continusbattleDistance;
    [HideInInspector] public float lastAttackTime;

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
    public void OpenStunnedWindow()
    {
        _canBeStunned  = true;
        counterAttackWindow.SetActive(true);
    }
    public void CloseStunnedWindow()
    {
        _canBeStunned = false;
        counterAttackWindow.SetActive(false);
    }
    
    public virtual bool attemptTpStunned()
    {
        if (_canBeStunned)
        {
            CloseStunnedWindow();
            return true;
        }
        else
        {
            return false;
        }
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;//»»¸öÑÕÉ«
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance, transform.position.y));
    }
    public void animationFinishTrigger()
    {
        stateMachine.currentState.animFinishTrigger();
    }
    public virtual RaycastHit2D isPlayerDetected() => Physics2D.Raycast(transform.position, Vector2.right * faceDir, 50, whatIsPlayer);
}
