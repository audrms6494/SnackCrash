using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnManager : MonoBehaviour
{
    public GameObject BlockPrefab;
    public Transform Spawnpoint_Block;

    void Start()
    {
        SpawnBricks(30);
    }

    public void SpawnBricks(int TotalBlocks)
    {
        float distanceX = 0;
        float distanceY = 0;
        Vector3 spawnPosition;
        // TotalBricks개의 BrickPrefab을 생성합니다.
        for (int i = 0; i < TotalBlocks; i++)
        {
            if (i % 5 == 0)
            {
                // 줄 바꿈
                distanceX = 0;
                distanceY -= 0.3f;
            }
            distanceX++;
            spawnPosition = Spawnpoint_Block.position + new Vector3(distanceX * 1.1f, distanceY, 0f);
            Instantiate(BlockPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
