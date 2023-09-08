using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectButton : MonoBehaviour
{
    private void Start()
    {

        if (!PlayerPrefs.HasKey("playerLevel") && !PlayerPrefs.HasKey("stageLevel"))
        {
            PlayerPrefs.SetInt("playerLevel", 0);
            PlayerPrefs.SetInt("stageLevel", 0);
        }

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
                LockStage();
            }
        }
    }

    void LockStage()
    {
        gameObject.transform.Find("StageLockPanel").gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
