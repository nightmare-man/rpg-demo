using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();    
    }
    // Start is called before the first frame update
    public void throwSword(Vector2 _dir, float _grvityScale)
    {
        rb.velocity = _dir; 
        rb.gravityScale = _grvityScale;
    }
    void Start()
    {
        anim.SetBool("rotate", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
