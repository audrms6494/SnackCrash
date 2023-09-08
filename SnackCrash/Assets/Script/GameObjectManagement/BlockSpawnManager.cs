using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class BlockSpawnManager : MonoBehaviour
{
    public MainSceneManager MainSceneManager;
    public List<GameObject> Blocks;
    public GameObject BlockPrefab;
    public Transform Spawnpoint_Block;
    public Color[] Colors; // ���� �迭�� ����
    private int colorIndex = -1; // ���� ���� �ε���
    public bool BlockClear = false;
    void Start()
    {
        //���⼭ ���̵��� ���� �ٸ� ���ڸ� ���� �� �ִ�. 
        SpawnBricks(30);
        if(MainSceneManager == null)
        {
            MainSceneManager = GameObject.FindObjectOfType<MainSceneManager>();
        }
    }

    public void SpawnBricks(int TotalBlocks)
    {
        BlockClear = false;
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
            block.GetComponent<Block>().SetManager(this);
            Blocks.Add(block);
           
            ChangeBlockColor(i, colorIndex);
          
        }
    }
    //��� ���� ����
    public void ChangeBlockColor(int BlockIndex, int ColorIndex)
    {
        if (colorIndex < Colors.Length)
        {
            SpriteRenderer spriteRenderer = Blocks[BlockIndex].GetComponent<SpriteRenderer>();
            spriteRenderer.color = Colors[colorIndex];
        }
    }

    public void DestroyBlock(GameObject Block)
    {
        if (Block != null && Blocks.Contains(Block))
        {
            Blocks.Remove(Block);
            Destroy(Block);
        }
        BlockClear = CheckBlockisZero();
        MainSceneManager.CheckClear(BlockClear);
    }

    public bool CheckBlockisZero()
    {
        if (Blocks.Count == 0)
        {
            return true;
        }
        return false;
    }
}
