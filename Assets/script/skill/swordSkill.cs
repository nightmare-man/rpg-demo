using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordSkill : baseSkill
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Vector2 throwSwordDir;
    [SerializeField] private float swordGravityScale;
    private player player;
    private void Start()
    {
        player = playerManager.instance.player;
    }
    public void throwSword(Transform _transform)
    {
        GameObject sword = Instantiate(prefab, _transform.position, _transform.rotation);
        Vector2 dir = new Vector2(throwSwordDir.x * player.faceDir, throwSwordDir.y);
        sword.GetComponent<swordController>().throwSword(dir, swordGravityScale);
    }
}
