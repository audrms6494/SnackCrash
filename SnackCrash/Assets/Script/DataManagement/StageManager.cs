using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject Canvas;

    private void Start()
    {
        // PlayerPrefs.DeleteAll();  // -- 송명근 -- 최고기록 점수 데이터까지 사라질 수 있음

        // playerLevel이 현재 플레이어가 깨고있는 레벨, stageLevel은 현재까지 열린 가장 어려운 레벨
        if (!PlayerPrefs.HasKey("playerLevel") && !PlayerPrefs.HasKey("stageLevel"))
        {
            PlayerPrefs.SetInt("playerLevel", 0);
            PlayerPrefs.SetInt("stageLevel", 1);
        }

        CheckStage(PlayerPrefs.GetInt("stageLevel"));
    }

    //void CheckAccessible(GameObject gameObject)
    //{

    //}

    //void CheckStage(int stageLevel)
    //{
    //    for (int i = stageLevel; i < 4; i++)
    //    {
    //        if (i + 1 > PlayerPrefs.GetInt("playerLevel"))
    //        {
    //            LockStage(i + 1);
    //        }
    //    }
    //}

    // -- 송명근  현재까지 깬 stage 확인 후 안깼으면 Lock
    void CheckStage(int stageLevel)
    {
        for (int i = stageLevel; i < 3; i++) 
        {
            LockStage(i + 1);
        }
    }

    void LockStage(int stageLevel)
    {
        if (stageLevel < 4)
        {
            Canvas.transform.Find($"Stage{stageLevel}LockPanel").gameObject.SetActive(true);
            Canvas.transform.Find($"Stage{stageLevel}").gameObject.SetActive(false);
        }
    }

    public void SetDifficultyEasy()
    {
        PlayerPrefs.SetInt("playerLevel", 1);
    }

    public void SetDifficultyNormal()
    {
        PlayerPrefs.SetInt("playerLevel", 2);
    }

    public void SetDifficultyHard()
    {
        PlayerPrefs.SetInt("playerLevel", 3);
    }
}