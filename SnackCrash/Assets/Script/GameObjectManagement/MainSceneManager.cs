using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    public BallSpawnManager SpawnManager_Ball;
    public BlockSpawnManager SpawnManager_Block;
    public EnemySpawnManager SpawnManager_Enemy;
    public GameObject Clear;
    public GameObject GameOver;
    public GameObject ClearEffect;
    public int FinishedScore;
    private int CuStage=0;
    private bool clear;
    private void Start()
    {
        clear = false;

        if (SpawnManager_Ball == null)
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
                    SpawnManager_Enemy.SpawnEnemy();
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

            // -- 송명근 게임 오버 됐을 때에도 점수 실행
            FinishedScore = SpawnManager_Block.CuScore;
            PlayerPrefs.SetInt("CurrentScore", FinishedScore);
        }
    }
    public void CheckClear(bool blockisZero)
    {
        //블록은 0 개 일때 게임 클리어
        if (blockisZero)
        {
            //적 파괴
            SpawnManager_Enemy.DestroyEnemy();
            Instantiate(ClearEffect);
          
            // 현재 스테이지 클리어 완료
            clear=true;
            int stageLevel = PlayerPrefs.GetInt("stageLevel"); // 현재까지 열린 stagelevel 확인
            Clear.SetActive(true);
            if (CuStage == stageLevel) // 만약 현재까지 열린 stagelevel중 가장 어려운 난이도를 깼다면 ( Current stage는 stagelevel을 넘을 수 없으므로 등호)
            {
                PlayerPrefs.SetInt("stageLevel", CuStage + 1); // 다음 스테이지 오픈!
            }
            Debug.Log("GameClear");
            FinishedScore = SpawnManager_Block.CuScore;
            //이 밑에 Score 저장.
            PlayerPrefs.SetInt("CurrentScore", FinishedScore);
        }
    }
}
