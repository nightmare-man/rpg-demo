using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillManager : MonoBehaviour
{
    public static skillManager instance;
    [HideInInspector] public dashSkill dashSkill;
    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }
    private void Start()
    {
        dashSkill = GetComponent<dashSkill>();
    }
}
