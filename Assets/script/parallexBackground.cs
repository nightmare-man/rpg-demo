using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class parallexBackground : MonoBehaviour
{
    [SerializeField] private float parallaxEffect;
    private GameObject cam;

    public float length;
    private float startX;

    private void Start()
    {
        cam = GameObject.Find("Main Camera");
        startX = transform.position.x;
    }

    private void Update()
    {
        float toMove = cam.transform.position.x * parallaxEffect;
        float distance = cam.transform.position.x * (1 - parallaxEffect);
      
        transform.position = new Vector3(startX + toMove, transform.position.y);
        if (distance > length+startX)
        {
            startX += length;
        }else if (distance < startX-length)
        {
            startX -= length;
        }
    }
}
