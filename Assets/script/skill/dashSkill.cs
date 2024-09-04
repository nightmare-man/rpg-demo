using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashSkill : baseSkill
{
    protected override void useSkill()
    {
        base.useSkill();
        Debug.Log("leave a clone behind");
    }
}
