using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillManager : MonoBehaviour
{
    public static skillManager instance;
    [HideInInspector] public dashSkill dashSkill { get; private set; }
    [HideInInspector] public cloneSkill cloneSkill { get; private set; }
    [HideInInspector] public swordSkill swordSkill { get; private set; }
    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
        dashSkill = GetComponent<dashSkill>();
        cloneSkill = GetComponent<cloneSkill>();
        swordSkill = GetComponent<swordSkill>();
    }
    private void Start()
    {
        
    }
}
