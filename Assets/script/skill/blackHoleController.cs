using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackHoleController : MonoBehaviour
{
    [SerializeField] private float growSpeed;
    [SerializeField] private float maxSize;
    [SerializeField] private bool canGrow;
    [SerializeField] private List<Transform> targets;

    [Header("hotkey info")]
    [SerializeField] private GameObject hotkeyPrefab;
    [SerializeField] private List<KeyCode> hotkeyList;
    // Start is called before the first frame update
    private void Awake()
    {
        
        targets = new List<Transform>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (canGrow)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(maxSize, maxSize), growSpeed * Time.deltaTime);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hotkeyList.Count <= 0)
        {
            Debug.LogWarning("没有足够的候选按键列表");
            return;
        }
        if (collision.GetComponent<enemy>() != null)
        {
            enemyLogic(collision);

        }
    }

    private void enemyLogic(Collider2D collision)
    {
        //停止敌人
        //实例化按键文字
        //
        collision.GetComponent<enemy>().enterFreeze();
        KeyCode code = hotkeyList[Random.Range(0, hotkeyList.Count)];
        hotkeyList.Remove(code);
        GameObject hotkey = Instantiate(hotkeyPrefab, collision.transform.position + new Vector3(0, 2, 0), Quaternion.identity);
        //hotkey.transform.parent = transform;
        hotkey.GetComponent<hotkeyController>().setHotkey(code,collision.transform,this);
    }
    public void addTarget(Transform _transform)
    {
   
        targets.Add(_transform); 
    }
}
