using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class swordController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool canRotate = true;
    private CircleCollider2D cc;
    private bool isReturningSword;
    [SerializeField] private float returnSpeed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();    
        cc = GetComponent<CircleCollider2D>();
    }
    // Start is called before the first frame update
    public void throwSword(Vector2 _dir, float _grvityScale)
    {
        rb.velocity = _dir; 
        rb.gravityScale = _grvityScale;
        playerManager.instance.player.assignSword(gameObject);
    }
    public void returnSword()
    {
       // rb.isKinematic = true;
        transform.parent = null;
        isReturningSword = true;
        rb.constraints = RigidbodyConstraints2D.None;
    }
    void Start()
    {
       anim.SetBool("rotate", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(canRotate)
            transform.right = rb.velocity;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetBool("rotate", false);
        canRotate = false;
        cc.enabled = false;
        rb.isKinematic = true;
        transform.parent = collision.transform;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
