using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    private player _player;
    void Start()
    {
        _player = GetComponentInParent<player>();
    }

    public void animatorTrigger()
    {
      
        _player.AnimationTrigger();
    }
    private void attackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_player.attackCheckPoint.position, _player.attackCheckDistance);
        foreach(var hit in colliders)
        {
            if (hit.GetComponent<enemy>() != null)
            {
                hit.GetComponent<enemy>().OnDamage();
            }
        }
    }
    private void throwSword()
    {
        skillManager.instance.swordSkill.throwSword(_player.transform);
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
