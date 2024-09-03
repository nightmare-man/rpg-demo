using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entity : MonoBehaviour
{

    public float faceDir { get; private set; } = 1.0f;
    public bool faceRight { get; private set; } = true;

    #region collision info
    [Header("collision info")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private Transform wallCheckPoint;
    [SerializeField] public Transform attackCheckPoint;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] public float attackCheckDistance;
    [SerializeField] private LayerMask whatIsGround;
    #endregion

    #region components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    #endregion

    protected virtual void Awake()
    {

    }
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    protected virtual void Update()
    {

    }
    public virtual void flipController(float _x)
    {
        if (_x > 0 && !faceRight)
        {
            flip();
        }
        else if (_x < 0 && faceRight)
        {
            flip();
        }
    }
    public virtual void flip()
    {
        faceDir *= -1;
        faceRight = !faceRight;
        transform.Rotate(0, 180, 0);
    }
    public virtual void OnDamage()
    {
        Debug.Log(gameObject.name + " was damaged");
    }
    public void zeroVelocity() => rb.velocity = new Vector2(0, 0);
    public void setVelocity(float xVelocity, float yVelocity)
    {
        rb.velocity = new Vector2(xVelocity, yVelocity);
        flipController(xVelocity);
    }
    public  virtual bool isGrounded() => Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckDistance, whatIsGround);
    public  virtual bool isWallDetected() => Physics2D.Raycast(wallCheckPoint.position, Vector2.right * faceDir, wallCheckDistance, whatIsGround);

    protected virtual  void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheckPoint.position, new Vector3(groundCheckPoint.position.x, groundCheckPoint.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheckPoint.position, new Vector3(wallCheckPoint.position.x + wallCheckDistance, wallCheckPoint.position.y));
        Gizmos.DrawWireSphere(attackCheckPoint.position, attackCheckDistance);
    }
}
