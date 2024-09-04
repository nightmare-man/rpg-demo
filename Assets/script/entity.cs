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

    #region knock info
    [Header("knock info")]
    [SerializeField] private Vector2 knockBackDirection;
    [SerializeField] private float knockDuration;
    private bool knocked;
    #endregion

    #region components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public entityFlash ef { get; private set; }
    #endregion

    protected virtual void Awake()
    {

    }
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        ef = GetComponent<entityFlash>();
    }

    protected virtual void Update()
    {

    }
    public virtual void flipController(float _x)
    {
        if (_x > 0.001 && !faceRight)
        {
            flip();
        }
        else if (_x < -0.001 && faceRight)
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
        ef.StartCoroutine("fx");
        StartCoroutine("onKnockBack");
    }

    private IEnumerator onKnockBack()
    {
        knocked = true;
        rb.velocity=new Vector2(-faceDir * knockBackDirection.x, knockBackDirection.y);
        yield return new WaitForSeconds(knockDuration);
        knocked = false;
        zeroVelocity();
    }
    public void zeroVelocity() {
        setVelocity(0, 0);
    } 
    public void setVelocity(float xVelocity, float yVelocity)
    {
        if (knocked)
            return;
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
