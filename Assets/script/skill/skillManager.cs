using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillManager : MonoBehaviour
{
    public static skillManager instance;
    [HideInInspector] public dashSkill dashSkill { get; private set; }
    [HideInInspector] public cloneSkill cloneSkill { get; private set; }
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
        cloneSkill = GetComponent<cloneSkill>();
    }
}
