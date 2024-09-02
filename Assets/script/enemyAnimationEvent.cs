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

    public void FinishTrigger()
    {
        _enemy.animationFinishTrigger();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
