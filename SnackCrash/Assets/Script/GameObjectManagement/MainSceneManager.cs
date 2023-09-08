using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    public BallSpawnManager SpawnManager_Ball;
    public BlockSpawnManager SpawnManager_Block;

    public void CheckGameOver(bool ballisZero)
    {
        //���� 0 �� �϶� ���ӿ���
        if (ballisZero)
        {
            Debug.Log("GameOver");
        }
    }
    public void CheckClear(bool blockisZero)
    {
        //����� 0 �� �϶� ���� Ŭ����
        if (blockisZero)
        {
            Debug.Log("GameClear");
        }
    }
}
