using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{

    [Header("move info")]
    public float moveSpeed = 8.0f;
    public float jumpForce = 8.0f;

    [Header("collision info")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private Transform wallCheckPoint;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask whatIsGround;

    #region states
    public playerStateMachine stateMachine { get; private set; }
    public playerStateIdle playerIdle { get; private set; }
    public playerStateMove playerMove { get; private set; }
    public playerStateJump playerJump { get; private set; }
    public playerStateAir playerAir { get; private set; }
    #endregion

    #region components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    #endregion

    private void Awake()
    {
        stateMachine=new playerStateMachine();
        playerIdle  = new playerStateIdle(stateMachine,this,"playerIdle");
        playerMove  = new playerStateMove(stateMachine, this, "playerMove");
        playerJump  = new playerStateJump(stateMachine, this, "playerJump");
        playerAir   = new playerStateAir(stateMachine, this, "playerJump");
    }

    // Start is called before the first frame update
    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        stateMachine.initialize(playerIdle);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.currentState.update();
        
    }
    public void setVelocity(float xVelocity, float yVelocity)
    {
        rb.velocity = new Vector2(xVelocity, yVelocity);
    }
    public bool isGrounded() => Physics2D.Raycast(groundCheckPoint.position, Vector2.down);
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheckPoint.position, new Vector3(groundCheckPoint.position.x, groundCheckPoint.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheckPoint.position, new Vector3(wallCheckPoint.position.x + wallCheckDistance, wallCheckPoint.position.y));
    }
}
