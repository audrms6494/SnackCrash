using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class BlockSpawnManager : MonoBehaviour
{
    public MainSceneManager MainSceneManager;
    public List<GameObject> Blocks;
    public GameObject BlockPrefab;
    public Transform Spawnpoint_Block;
    public Color[] Colors; // 색상 배열로 변경
    private int colorIndex = -1; // 현재 색상 인덱스
    public bool BlockClear = false;

    public Transform[] SpawnPointForDiffiCulty;

    void Start()
    {
        SpawnBricksWidth(1,5,1);
    }
    //난이도에 따른 구현

   //블록 하나 만들어 배열에 넣어주는 메서드
    public void SpawnUti(int x, int y, int CIndex)
    {
        BlockClear = false;
        Vector3 spawnPosition;
        spawnPosition = Spawnpoint_Block.position + new Vector3(x * 1.1f, y*-0.3f, 0f);
        GameObject block = Instantiate(BlockPrefab, spawnPosition, Quaternion.identity);
        block.GetComponent<Block>().SetManager(this);
        ChangeBlockColor(block, CIndex);
        Blocks.Add(block);
    }

    //세로로 position 위치에 한 줄
    public void SpawnBricksWidth(int start, int finish, int position)
    {
        for (int j = start; j <= finish; j++)
        {
            SpawnUti(j, position, j);
        }
    }
    //세로 한 줄
    public void SpawnBricksWidth(int start, int position)
    {
        for (int j = start; j < 5 ; j++)
        {
            SpawnUti(j, position, j);
        }
    }
    //가로로 position 위치에 한 줄
    public void SpawnBricksLine(int start, int finish,int position)
    {
        for (int j = start; j <= finish; j++)
        {
            SpawnUti(position, j, j);
        }
    }
    //가로 한줄
    public void SpawnBricksLine(int start, int position)
    {
        for (int j = start; j < 5; j++)
        {
            SpawnUti(position, j, j);
        }
    }



    //블록 색깔 수정
    public void ChangeBlockColor(GameObject block, int CIndex)
    {
        if (colorIndex < Colors.Length)
        {
            SpriteRenderer spriteRenderer = block.GetComponent<SpriteRenderer>();
            spriteRenderer.color = Colors[CIndex];
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
