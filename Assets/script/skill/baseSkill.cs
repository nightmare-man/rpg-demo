using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseSkill : MonoBehaviour
{
    public float cooldown;
    private float cooldownTimer;
    protected player player;

    //有关c#继承， 父类方法只要不是private，都会默认继承。
    //而virutal只是表明子类可以重写，子类不重新声明，则使用继承
    protected virtual void Start()
    {
        player = playerManager.instance.player;
    }
    protected virtual void Update()
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
