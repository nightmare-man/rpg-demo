using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseSkill : MonoBehaviour
{
    public float cooldown;
    private float cooldownTimer;
    protected player player;

    //�й�c#�̳У� ���෽��ֻҪ����private������Ĭ�ϼ̳С�
    //��virutalֻ�Ǳ������������д�����಻������������ʹ�ü̳�
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
