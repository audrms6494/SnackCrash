using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject Canvas;

    private void Start()
    {

        if (!PlayerPrefs.HasKey("playerLevel") && !PlayerPrefs.HasKey("stageLevel"))
        {
            PlayerPrefs.SetInt("playerLevel", 0);
            PlayerPrefs.SetInt("stageLevel", 1);
        }
        Debug.Log(PlayerPrefs.GetInt("playerLevel"));

        CheckStage(PlayerPrefs.GetInt("playerLevel"));
    }

    void CheckAccessible(GameObject gameObject)
    {

    }

    void CheckStage(int playerLevel)
    {
        for (int i = playerLevel; i < 4; i++)
        {
            if (i + 1 < PlayerPrefs.GetInt("stageLevel"))
            {
                LockStage(PlayerPrefs.GetInt("stageLevel"));
            }
        }
    }

    void LockStage(int stageLevel)
    {
        Canvas.transform.Find($"Stage{stageLevel}LockPanel").gameObject.SetActive(true);
        Canvas.transform.Find($"Stage{stageLevel}").gameObject.SetActive(false);
    }
}
