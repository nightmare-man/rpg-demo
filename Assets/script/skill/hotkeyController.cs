using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hotkeyController : MonoBehaviour
{
    private KeyCode myKeyCode;
    private TextMeshProUGUI textMeshPro;
    private Transform enemy;
    private blackHoleController controller;
    // Start is called before the first frame update
    public void setHotkey(KeyCode _keycode, Transform _enemy, blackHoleController _controller)
    {
        myKeyCode = _keycode;
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        textMeshPro.text = _keycode.ToString();
        controller = _controller;
        enemy = _enemy;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(myKeyCode))
        {
            controller.addTarget(enemy);
            Destroy(gameObject);

        }
    }
}
