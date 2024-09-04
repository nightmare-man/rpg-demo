using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{

    //单例
    public static playerManager instance;
    public player player;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);//删除重复的游戏对象
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
