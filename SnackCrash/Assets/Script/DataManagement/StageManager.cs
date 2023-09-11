using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject Canvas;

    private void Start()
    {
        // PlayerPrefs.DeleteAll();  // -- �۸�� -- �ְ��� ���� �����ͱ��� ����� �� ����

        // playerLevel�� ���� �÷��̾ �����ִ� ����, stageLevel�� ������� ���� ���� ����� ����
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

    // -- �۸��  ������� �� stage Ȯ�� �� �Ȳ����� Lock
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