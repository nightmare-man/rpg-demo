using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class clonePlayerController : MonoBehaviour
{
    [SerializeField] private float duration = 1.0f;
    [SerializeField] private float colorMinusSpeed = 1.0f;
    [SerializeField] private Transform attackCheck;
    [SerializeField] private float attackRadius;
    private SpriteRenderer sr;
    private Animator anim;
    private float timer;
    private Transform clonePlayer;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        timer = duration;
        clonePlayer = transform.parent;
    }
    public void setup(Transform _transform, bool canAttack)
    {
        Debug.Log(_transform.position);
        gameObject.transform.position = _transform.position;
        if (canAttack)
        {


            anim.SetInteger("attackNumber", UnityEngine.Random.Range(0, 3));
            faceEnemy();
        }
            
            
    }
   

    // Update is called once per frame
    void Update()
    {
       
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            sr.color = new Color(sr.color.r,sr.color.g,sr.color.b,sr.color.a-colorMinusSpeed);
            if (sr.color.a < 0)
            {
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
    }

    public void animatorTrigger()
    {
        anim.SetInteger("attackNumber", -2);
        Debug.Log("finish attack");
    }
    public void attackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackCheck.position,attackRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<enemy>() != null)
            {
                hit.GetComponent<enemy>().OnDamage();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackCheck.position, attackRadius);
    }
    private  bool faceRight()
    {
        if (attackCheck.position.x > clonePlayer.position.x)
            return true;
        return false;
    }
    private void flip() => clonePlayer.Rotate(0, 180, 0);
    private void faceEnemy()
    {
        float nearestDistance = float.MaxValue;
        Transform nearestEnemy = null;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(clonePlayer.position, 25);
        foreach (var hit in colliders) 
        {
            if (hit.GetComponent<enemy>() != null)
            {
                float distance = Vector2.Distance(clonePlayer.position, hit.gameObject.transform.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestEnemy = hit.gameObject.transform;
                }
            }
        }
        if (nearestEnemy != null)
        {
            if (faceRight())
            {
                if (nearestEnemy.position.x < clonePlayer.position.x)
                    flip();
            }
            else
            {
                if (nearestEnemy.position.x > clonePlayer.position.x)
                    flip();
            }
        }
    }
}
