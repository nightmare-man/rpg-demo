using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseSkill : MonoBehaviour
{
    public float cooldown;
    private float cooldownTimer;
    private void Update()
    {
        cooldownTimer -=Time.deltaTime;
    }

    public virtual bool attemptToUse()
    {
        if (cooldownTimer < 0)
        {
            cooldownTimer = cooldown;
            useSkill();
            return true;
        }
        else
        {
            Debug.Log("skill in cooldown");
            return false;
        }
    }
    protected virtual void useSkill()
    {
        
    }
}
