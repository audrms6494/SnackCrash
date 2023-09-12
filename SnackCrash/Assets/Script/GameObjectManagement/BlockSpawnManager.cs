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
    public Sprite[] Colors; // ���� �迭�� ����
    private int colorIndex = -1; // ���� ���� �ε���
    public bool BlockClear = false;

    public Transform[] SpawnPointForDifficulty;

    //Score ���� �ʵ�
    public int CuScore = 0;
    public TextMeshProUGUI Score;

    //���̵��� ���� ����
    public void SpawnPattern1()
    {
        SpawnBricksWidth(0, 5, 1);
        SpawnBricksWidth(0, 5, 2);
    }
    public void SpawnPattern2()
    {
        SpawnBricksHeight(0,5,0);
        SpawnBricksHeight(0,5,1);
        SpawnBricksHeight(0,5,2);
        SpawnBricksHeight(0,5,3);
    }
    public void SpawnPattern3()
    {
        SpawnUti(0, 0, 1);
        SpawnUti(4, 0, 2);
        SpawnUti(1, 1, 0);
        SpawnUti(3, 1, 1 );
        SpawnUti(2, 2, 0);
        SpawnUti(1, 3, 2);
        SpawnUti(3, 3, 1);
        SpawnUti(0, 4, 2);
        SpawnUti(4, 4, 1);
    }

    //��� �ϳ� ����� �迭�� �־��ִ� �޼���,
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

    //���η� position ��ġ�� �� ��
    public void SpawnBricksWidth(int start, int finish, int position)
    {
        for (int j = start; j < finish; j++)
        {
            SpawnUti(j, position, 0);
        }
    }
    //���� �� ��
    public void SpawnBricksWidth(int start, int position)
    {
        for (int j = start; j < 5 ; j++)
        {
            SpawnUti(j, position, 0);
        }
    }
    //���η� position ��ġ�� �� ��
    public void SpawnBricksHeight(int start, int finish,int position)
    {
        for (int j = start; j < finish; j++)
        {
            SpawnUti(position, j, 1);
        }
    }
    //���� ����
    public void SpawnBricksHeight(int start, int position)
    {
        for (int j = start; j < 5; j++)
        {
            SpawnUti(position, j, 1);
        }
    }

    //��� ���� ����
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
