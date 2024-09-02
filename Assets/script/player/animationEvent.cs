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

    // Update is called once per frame
    void Update()
    {
        
    }
}
