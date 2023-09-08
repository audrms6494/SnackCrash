using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject Canvas;

    private void Start()
    {
        PlayerPrefs.DeleteAll();

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

    void CheckStage(int stageLevel)
    {
        for (int i = stageLevel; i < 4; i++)
        {
            if (i + 1 > PlayerPrefs.GetInt("playerLevel"))
            {
                LockStage(i + 1);
            }
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
}