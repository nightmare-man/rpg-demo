using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class player : MonoBehaviour
{

    [Header("move info")]
    public float moveSpeed = 8.0f;
    public float jumpForce = 8.0f;
    public float faceDir { get; private set; } = 1.0f;
    public bool faceRight { get; private set; } = true;

    [Header("dash info")]
    public float dashTime = 0.3f;
    public float dashSpeed = 18.0f;
    public float dashDir = 1.0f;


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
    public playerStateDash playerDash { get; private set; }
    public playerStateWallSlide playerWallSlide { get; private set; }
    public playerStateWallJump playerStateWallJump { get; private set; }
    public playerStateAttack playerStateAttack { get; private set; }
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
        playerDash  = new playerStateDash(stateMachine, this, "playerDash");
        playerWallSlide = new playerStateWallSlide(stateMachine, this, "playerWallSlide");
        playerStateWallJump = new playerStateWallJump(stateMachine, this, "playerJump");
        playerStateAttack = new playerStateAttack(stateMachine, this, "playerAttack");
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
        //放在这儿确保任何时候都能dash
        dashInputCheck();

    }

    private void dashInputCheck()
    {
        if (isWallDetected())
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //实现dash瞬间能够修改方向
            dashDir = Input.GetAxisRaw("Horizontal");
            if (dashDir == 0)
                dashDir = faceDir;
            //这里不需要因为dash方向和face方向不同而手动flip
            //因为dash的update里调用了setVelocity
            stateMachine.changeState(playerDash);
        }
    }

    public void setVelocity(float xVelocity, float yVelocity)
    {
        rb.velocity = new Vector2(xVelocity, yVelocity);
        flipController(xVelocity);
    }
    public bool isGrounded() => Physics2D.Raycast(groundCheckPoint.position, Vector2.down,groundCheckDistance,whatIsGround);
    public bool isWallDetected() => Physics2D.Raycast(wallCheckPoint.position, Vector2.right * faceDir, wallCheckDistance, whatIsGround);

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheckPoint.position, new Vector3(groundCheckPoint.position.x, groundCheckPoint.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheckPoint.position, new Vector3(wallCheckPoint.position.x + wallCheckDistance, wallCheckPoint.position.y));
    }
    public void flipController(float _x)
    {
        if(_x>0 && !faceRight)
        {
            flip();
        }else if(_x<0 && faceRight)
        {
            flip();
        }
    }
    private void flip()
    {
        faceDir *= -1;
        faceRight = !faceRight;
        transform.Rotate(0, 180, 0);
    }
    public void AnimationTrigger() => stateMachine.currentState.animatorFinishTrigger();
}
