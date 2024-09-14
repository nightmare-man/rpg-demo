using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum swordType
{
    regualr,
    bouncing,
    pierce,
    spin
}
public class swordSkill : baseSkill
{
    [Header("sword type")]
    [SerializeField] private swordType swordType;

    [Header("bouncing info")]
    [SerializeField] private float bouncingSpeed;
    [SerializeField] private int bouncingAmount;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] private float bouneGravity;

    [Header("throw info")]
    [SerializeField] private GameObject swordPrefab;
    [SerializeField] private Vector2 launchDir;//这个是预设被扔出去的速度向量
    [SerializeField] private float normalGravity;
    [SerializeField] private float returnSpeed;
    private Vector2 finalDir;//经过鼠标选择的方向后缩放launchDir得到的。

    [Header("tip dot info")]
    [SerializeField] private bool showDotTip;
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] private int dotsCount;
    [SerializeField] private float dotTimeInterval;

    [Header("catch info")]
    public float hitBackVelocity;       
    private GameObject[] dots;
    private GameObject dotsParent;
   
    protected override void Start()
    {
        base.Start();
        dotsParent = new GameObject("dotParent");
        createDots();
        
    }
    public void throwSword(Transform _transform)
    {
        
        GameObject sword = Instantiate(swordPrefab);
        sword.transform.position = _transform.position;
        switch (swordType)
        {
            case swordType.bouncing:
                sword.GetComponent<swordController>().setBouncing(true, bouncingAmount, bouncingSpeed, enemyLayer);
                normalGravity = bouneGravity;
                break;
            default:
                break;
        }
        sword.GetComponent<swordController>().throwSword(finalDir, normalGravity,returnSpeed);
       
    }
   
    protected override void Update()
    {
        base.Update();
        Vector2 aimDir= AimDirection().normalized;
        //计算加权方向
        finalDir = new Vector2(aimDir.x * launchDir.x, aimDir.y * launchDir.y);
        setDotsPostion();
    }

    #region aim region
    private Vector2 AimDirection()
    {
        Vector2 playerPosition = player.transform.position;
        //screenToWorldPoint是点击所在的屏幕坐标（也是3维的，点到的物体离相机距离不同，z不同）
        //这里因为人物背景什么的z相同，且是正交投影，因此离相机距离相同
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 ret = mousePosition - playerPosition;
       
       
        return ret;
    }

   
    private void createDots()
    {
        if (!showDotTip)
        {
            dotsCount = 0;
            return;
        }
        dots = new GameObject[dotsCount];
        for (int i = 0; i < dotsCount; i++)
        {
          
            dots[i] = Instantiate(dotPrefab);
            dots[i].SetActive(false);
            dots[i].transform.parent = dotsParent.transform;
        }
    }
  
    public void setDotsActivate(bool activate)
    {
        if (!showDotTip)
            return;
       
        foreach(var d in dots)
        {
            d.SetActive(activate);
        }
    }
    private void setDotPosition(Transform dot,float t)
    {
        Vector2 startPos = player.transform.position;
        Vector2 movePos = new Vector2(finalDir.x * t, finalDir.y * t + 0.5f * Physics2D.gravity.y * normalGravity*t*t);
        dot.position = startPos + movePos;
    }
    public void setDotsPostion()
    {
        if (!showDotTip)
            return;
      
        for (int i = 0; i < dotsCount; i++)
        {
            float t = (i+1) * dotTimeInterval;
            setDotPosition(dots[i].transform, t);
        }
    }
    #endregion
}
