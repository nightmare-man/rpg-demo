using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class swordController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool canRotate;
    private CircleCollider2D cc;
    private bool isReturningSword;
    private float returnSpeed;
    private bool isBouncing;
    private float bouncingSpeed;
    private int bouncingAmount;
    private List<Transform> targets;
    private LayerMask whatIsEnemy;
    private int nextTarget;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();    
        cc = GetComponent<CircleCollider2D>();
        targets = new List<Transform>();
        canRotate = true;
        nextTarget = 0;
    }
    // Start is called before the first frame update
    public void throwSword(Vector2 _dir, float _grvityScale, float _returnSpeed)
    {
        rb.velocity = _dir; 
        rb.gravityScale = _grvityScale;
        returnSpeed = _returnSpeed;
        playerManager.instance.player.assignSword(gameObject);
    }
    public void setBouncing(bool _isBouncing,int _bouncingAmount,float _bouncingSpeed,LayerMask _enemy)
    {
        isBouncing = _isBouncing;
        bouncingAmount = _bouncingAmount;
        bouncingSpeed = _bouncingSpeed;
        whatIsEnemy = _enemy;
    }
    public void returnSword()
    {   
        
        transform.parent = null;
        isReturningSword = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    void Start()
    {
       anim.SetBool("rotate", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate)
            transform.right = rb.velocity;
        returnLogic();
        bouncingLogic();
    }

    private void returnLogic()
    {
        if (isReturningSword)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerManager.instance.player.transform.position, returnSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, playerManager.instance.player.transform.position) < 1.0f)
            {
                isReturningSword = false;
                playerManager.instance.player.clearSword();//剑被摧毁了，也不用担心isReturningSword没有被重置成false了

            }
        }
    }

    private void bouncingLogic()
    {
        if (isReturningSword)
            return;
        if (isBouncing && targets.Count > 0)
        {
            if (bouncingAmount == 0)
            {
                isBouncing = false;
                isReturningSword = true;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, targets[nextTarget].position, bouncingSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, targets[nextTarget].position) < 0.1f)
                {
                    targets[nextTarget].GetComponent<enemy>().OnDamage();
                    targets[nextTarget].GetComponent<enemy>().StartCoroutine("freezeTime", 1.0f);
                    nextTarget++;
                    if (nextTarget >= targets.Count)
                        nextTarget = 0;
                    bouncingAmount--;

                }
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isReturningSword)
            return;

        if (collision.GetComponent<enemy>() != null)
        {
            Debug.Log("is enemy");
            Collider2D[] colliders = Physics2D.OverlapCircleAll(collision.transform.position, 20,whatIsEnemy);
            foreach(var hit in colliders)
            {
                targets.Add(hit.transform);
            }
        }
        stuckSword(collision);

    }
    private void stuckSword(Collider2D collision)
    {

        canRotate = false;//不改变方向了
        cc.enabled = false;//不再检测碰撞了
        rb.isKinematic = true; //不再受力影响了
        rb.constraints = RigidbodyConstraints2D.FreezeAll;//原来的运动也停止了
        if (isBouncing && targets.Count > 0)
            return;

        anim.SetBool("rotate", false);
        
        transform.parent = collision.transform;

    }
}
