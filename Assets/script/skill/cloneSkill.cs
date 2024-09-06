using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cloneSkill : baseSkill
{
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private bool canAttack;

    public void setClone(Transform _transform)
    {
        GameObject clone = Instantiate(clonePrefab);
        clone.GetComponentInChildren<clonePlayerController>().setup(_transform, canAttack);
    }

}
