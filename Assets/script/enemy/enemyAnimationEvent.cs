using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAnimationEvent : MonoBehaviour
{

    private enemy _enemy;
    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponentInParent<enemy>();
    }
    public void attackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_enemy.attackCheckPoint.position, _enemy.attackCheckDistance);
        foreach(var hit in colliders)
        {
            if (hit.GetComponent<player>() != null)
            {
                hit.GetComponent<player>().OnDamage();
            }
        }
    }
    public void FinishTrigger()
    {
        _enemy.animationFinishTrigger();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
