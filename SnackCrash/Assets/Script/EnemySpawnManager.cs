using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public BlockSpawnManager BlockSpawnManager;
    public GameObject EnemyPrefab;
    public GameObject CurrnetEnemy;
    public Enemy cuEnemy;
    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(EnemyPrefab);
        CurrnetEnemy = enemy;
        cuEnemy=enemy.GetComponent<Enemy>();
        cuEnemy.SetBSManager(BlockSpawnManager);
    }
    public void DestroyEnemy()
    {
        if(CurrnetEnemy != null)
        {
            cuEnemy.Dead();
        }
        else
        {
            return;
        }
    }
}
