using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class BlockSpawnManager : MonoBehaviour
{
    public MainSceneManager MainSceneManager;
    public ItemSpawnManager ItemSpawnManager;
    public List<GameObject> Blocks;
    public GameObject BlockPrefab;
   
    public Transform Spawnpoint_Block;
    public Sprite[] Colors; // 색상 배열로 변경
    private int colorIndex = -1; // 현재 색상 인덱스
    public bool BlockClear = false;

    public Transform[] SpawnPointForDifficulty;

    //Score 관련 필드
    public int CuScore = 0;
    public TextMeshProUGUI Score;
    public GameObject ScoreEffect;
    //난이도에 따른 구현
    public void SpawnPattern1()
    {
        SpawnBricksWidth(0, 5, 1, 0);
        SpawnBricksWidth(0, 5, 2, 1);
    }
    public void SpawnPattern2()
    {
        SpawnBricksHeight(0,5,0,0);
        SpawnBricksHeight(0,5,1,1);
        SpawnBricksHeight(0,5,3,0);
        SpawnBricksHeight(0,5,4,1);
    }
    public void SpawnPattern3()
    {
        SpawnUti(0, 0, 1);
        SpawnUti(4, 0, 1);
        SpawnUti(1, 1, 0);
        SpawnUti(3, 1, 1) ;
        SpawnUti(2, 2, 0);
        SpawnUti(1, 3, 1);
        SpawnUti(3, 3, 1);
        SpawnUti(0, 4, 0);
        SpawnUti(4, 4, 1);
    }

    //블록 하나 만들어 배열에 넣어주는 메서드,
    public void SpawnUti(int x, int y, int CIndex)
    {
        BlockClear = false;
        Vector3 spawnPosition;
        spawnPosition = Spawnpoint_Block.position + new Vector3(x * 1.1f, y*-0.6f, 0f);
        GameObject block = Instantiate(BlockPrefab, spawnPosition, Quaternion.identity);
        block.GetComponent<Block>().SetManager(this);
        ChangeBlockColor(block, CIndex);
        Blocks.Add(block);
    }

    //가로로 position 위치에 한 줄
    public void SpawnBricksWidth(int start, int finish, int position)
    {
        for (int j = start; j < finish; j++)
        {
            SpawnUti(j, position, 1);
        }
    }
    //가로 한 줄
    public void SpawnBricksWidth(int start, int position)
    {
        for (int j = start; j < 5 ; j++)
        {
            SpawnUti(j, position, 1);
        }
    }
    //가로로 position 위치에 한 줄, Spirte 선택
    public void SpawnBricksWidth(int start, int finish, int position, int CIndex)
    {
        for (int j = start; j < finish; j++)
        {
            SpawnUti(j, position, CIndex);
        }
    }
    //세로로 position 위치에 한 줄
    public void SpawnBricksHeight(int start, int finish,int position)
    {
        for (int j = start; j < finish; j++)
        {
            SpawnUti(position, j, 1);
        }
    }
    //세로로 position 위치에 한 줄, Spirt 선택
    public void SpawnBricksHeight(int start, int finish, int position, int CIndex)
    {
        for (int j = start; j < finish; j++)
        {
            SpawnUti(position, j, CIndex);
        }
    }

    //세로 한줄
    public void SpawnBricksHeight(int start, int position)
    {
        for (int j = start; j < 5; j++)
        {
            SpawnUti(position, j, 1);
        }
    }

    //블록 색깔 수정
    public void ChangeBlockColor(GameObject block, int CIndex)
    {
        if (colorIndex < Colors.Length)
        {
            SpriteRenderer spriteRenderer = block.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = Colors[CIndex];
        }
    }

    public void DestroyBlock(GameObject Block)
    {
        if (Block != null && Blocks.Contains(Block))
        {
            CuScore += 10;
            Score.text = CuScore.ToString();
            GameObject Effect= Instantiate(ScoreEffect, Block.transform.position, Quaternion.identity);
            Destroy(Effect, 0.5f);
            ItemSpawnManager.CallBlockBreak(Block.transform);
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
