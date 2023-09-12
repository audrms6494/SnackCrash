using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    public BallSpawnManager SpawnManager_Ball;
    public BlockSpawnManager SpawnManager_Block;
    public GameObject Clear;
    public GameObject GameOver;
    public int FinishedScore;
    private int CuStage=0;
    private bool clear = false;
    private void Start()
    {
        if(SpawnManager_Ball == null)
        {
            SpawnManager_Ball = GameObject.FindObjectOfType<BallSpawnManager>();
        }
        if(SpawnManager_Block == null)
        {
            SpawnManager_Block = GameObject.FindObjectOfType<BlockSpawnManager>();
        }
        if (PlayerPrefs.HasKey("playerLevel"))
        {
           CuStage= PlayerPrefs.GetInt("playerLevel");
           if(CuStage<1 || CuStage > 3)
           {
                Debug.Log("PlayerPrefs.GetInt(playerLevel) is Not 1~3");
                CuStage = 3;
           }
           switch(CuStage)
           {
                case 1:
                    SpawnManager_Block.SpawnPattern1();
                    SpawnManager_Ball.SpawnBall_velocity();
                    break; 
                case 2:
                    SpawnManager_Block.SpawnPattern2();
                    SpawnManager_Ball.SpawnBall_velocity();
                    break; 
                case 3:
                    SpawnManager_Block.SpawnPattern3();
                    SpawnManager_Ball.SpawnBall_velocity();
                    break;
                default: 
                    break;
           }
        }
        else
        {
            Debug.Log("PlayerPrefs.HasKey(playerLevel) == Null");
        }
    }
    public void CheckGameOver(bool ballisZero)
    {
        if (ballisZero && !clear)
        {
            GameOver.SetActive(true);
            Debug.Log("GameOver");
        }
    }
    public void CheckClear(bool blockisZero)
    {
        //블록은 0 개 일때 게임 클리어
        if (blockisZero)
        {
            clear=true;
            int stageLevel = PlayerPrefs.GetInt("stageLevel");
            Clear.SetActive(true);
            if (CuStage>stageLevel)
            {
                PlayerPrefs.SetInt("stageLevel", CuStage);
            }
            Debug.Log("GameClear");
            FinishedScore = SpawnManager_Block.CuScore;
            //이 밑에 Score 저장.
            PlayerPrefs.SetInt("CurrentScore", FinishedScore);
        }
    }
}
