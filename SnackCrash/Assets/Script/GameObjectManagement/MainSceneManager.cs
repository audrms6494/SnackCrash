using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    public BallSpawnManager SpawnManager_Ball;
    public BlockSpawnManager SpawnManager_Block;

    public void CheckGameOver(bool ballisZero)
    {
        //공은 0 개 일때 게임오버
        if (ballisZero)
        {
            Debug.Log("GameOver");
        }
    }
    public void CheckClear(bool blockisZero)
    {
        //블록은 0 개 일때 게임 클리어
        if (blockisZero)
        {
            Debug.Log("GameClear");
        }
    }
}
