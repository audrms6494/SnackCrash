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

            // -- �۸�� ���� ���� ���� ������ ���� ����
            FinishedScore = SpawnManager_Block.CuScore;
            PlayerPrefs.SetInt("CurrentScore", FinishedScore);
        }
    }
    public void CheckClear(bool blockisZero)
    {
        //����� 0 �� �϶� ���� Ŭ����
        if (blockisZero)
        {
            //�� �ı�
            SpawnManager_Enemy.DestroyEnemy();
            Instantiate(ClearEffect);
          
            // ���� �������� Ŭ���� �Ϸ�
            clear=true;
            int stageLevel = PlayerPrefs.GetInt("stageLevel"); // ������� ���� stagelevel Ȯ��
            Clear.SetActive(true);
            if (CuStage == stageLevel) // ���� ������� ���� stagelevel�� ���� ����� ���̵��� ���ٸ� ( Current stage�� stagelevel�� ���� �� �����Ƿ� ��ȣ)
            {
                PlayerPrefs.SetInt("stageLevel", CuStage + 1); // ���� �������� ����!
            }
            Debug.Log("GameClear");
            FinishedScore = SpawnManager_Block.CuScore;
            //�� �ؿ� Score ����.
            PlayerPrefs.SetInt("CurrentScore", FinishedScore);
        }
    }
}
