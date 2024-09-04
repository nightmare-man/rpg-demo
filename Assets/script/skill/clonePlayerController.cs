using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clonePlayerController : MonoBehaviour
{
    [SerializeField] private float duration = 1.0f;
    [SerializeField] private float colorMinusSpeed = 1.0f;
    private SpriteRenderer sr;
    private float timer;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        timer = duration;
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
                Destroy(gameObject);
            }
        }
    }
}
