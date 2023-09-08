using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnManager : MonoBehaviour
{
    public List<GameObject> Blocks;
    public GameObject BlockPrefab;
    public Transform Spawnpoint_Block;
    public Color[] Colors; // 색상 배열로 변경
    private int colorIndex = -1; // 현재 색상 인덱스

    void Start()
    {
        SpawnBricks(30);
    }

    public void SpawnBricks(int TotalBlocks)
    {
        float distanceX = 0;
        float distanceY = 0;
        Vector3 spawnPosition;

        for (int i = 0; i < TotalBlocks; i++)
        {
            if (i % 5 == 0)
            {
                distanceX = 0;
                distanceY -= 0.3f;
                colorIndex++;
            }
            distanceX++;
            spawnPosition = Spawnpoint_Block.position + new Vector3(distanceX * 1.1f, distanceY, 0f);
            GameObject block = Instantiate(BlockPrefab, spawnPosition, Quaternion.identity);
            Blocks.Add(block);

            if (colorIndex < Colors.Length)
            {
                SpriteRenderer spriteRenderer = block.GetComponent<SpriteRenderer>();
                spriteRenderer.color = Colors[colorIndex];
            }
        }
    }
}
