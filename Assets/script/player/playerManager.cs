using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{

    //����
    public static playerManager instance;
    public player player;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);//ɾ���ظ�����Ϸ����
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
