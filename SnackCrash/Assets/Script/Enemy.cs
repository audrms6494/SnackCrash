using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public BlockSpawnManager BsManager;
    public float AttackDelay;
    public float time;
    public int AttackCount;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        time = 0;
        AttackCount = 0;
    }
    private void Update()
    {
        time += Time.deltaTime;
        if(time > AttackDelay)
        {
            time = 0;
            BsManager.SpawnBricksWidth(0,AttackCount);
            AttackCount++;
        }
    }
}
