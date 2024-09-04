using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class cloneSkill : baseSkill
{
    public GameObject clonePrefab;
    public void setClone(Transform transform)
    {
        GameObject clone = Instantiate(clonePrefab);
        clone.transform.position = transform.position;
    }

}
