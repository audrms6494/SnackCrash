using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public BlockSpawnManager BsManager;
    public float AttackDelay;
    public float time;
    public int AttackCount;
    public bool isDead;
    private void Start()
    {
        time = 0;
        AttackCount = 0;
        isDead = false;
        animator=GetComponent<Animator>();
    }
    private void Update()
    {
        if (!isDead)
        {
            time += Time.deltaTime;
            if (time > AttackDelay)
            {
                time = 0;
                if (AttackCount > 13) return;
                BsManager.SpawnBricksWidth(0, 4, AttackCount,2);
                AttackCount++;
            }
        }
    }
    public void Dead()
    {
        isDead = true;
        animator.SetTrigger("Dead");
        Destroy(this.gameObject, 1.0f);
    }

    public void SetBSManager(BlockSpawnManager bsManager)
    {
        BsManager = bsManager;
    }
}
