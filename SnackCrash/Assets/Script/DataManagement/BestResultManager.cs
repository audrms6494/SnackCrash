using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestResultManager : MonoBehaviour
{
    private string keyValue;
    private string[] difficultyArr = new string[] { "Easy", "Normal", "Hard" };
    private string[] nameArr = new string[] { "Andy", "Billy", "Charlie" };
    public int difficulty;

    [SerializeField] private TMP_Text first;
    [SerializeField] private TMP_Text second;
    [SerializeField] private TMP_Text third;

    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.DeleteAll();
        // 최고점수 초기화
        // 처음 한번만 실행한 뒤 실행 x
        if (!PlayerPrefs.HasKey("Start"))
        { 
            for (int i = 0; i < 3; i++) // 난이도별
            {
                for (int j = 1; j < 4; j++) // 등수별
                {
                    keyValue = difficultyArr[i] + j.ToString() + "Name";
                    PlayerPrefs.SetString(keyValue, nameArr[j-1]);
                    keyValue = difficultyArr[i] + j.ToString() + "Score";
                    PlayerPrefs.SetInt(keyValue, (4 - j) * 10);
                }
            }
            PlayerPrefs.SetString("Start", "StartComplete");
        }

        if (difficulty == 1)
        {
            WriteEasyResult();
        }

        else if (difficulty == 2)
        {
            WriteNormalResult();
        }

        else if (difficulty == 3)
        {
            WriteHardResult();
        }
    }


    public void WriteEasyResult()
    {
        first.text = "1st) " + PlayerPrefs.GetString("Easy1Name") + "\t" + PlayerPrefs.GetInt("Easy1Score");
        second.text = "2nd) " + PlayerPrefs.GetString("Easy2Name") + "\t" + PlayerPrefs.GetInt("Easy2Score");
        third.text = "3rd) " + PlayerPrefs.GetString("Easy3Name") + "\t" + PlayerPrefs.GetInt("Easy3Score");
    }

    public void WriteNormalResult()
    {
        first.text = "1st) " + PlayerPrefs.GetString("Normal1Name") + "\t" + PlayerPrefs.GetInt("Normal1Score");
        second.text = "2nd) " + PlayerPrefs.GetString("Normal2Name") + "\t" + PlayerPrefs.GetInt("Normal2Score");
        third.text = "3rd) " + PlayerPrefs.GetString("Normal3Name") + "\t" + PlayerPrefs.GetInt("Normal3Score");
    }

    public void WriteHardResult()
    {
        first.text = "1st) " + PlayerPrefs.GetString("Hard1Name") + "\t" + PlayerPrefs.GetInt("Hard1Score");
        second.text = "2nd) " + PlayerPrefs.GetString("Hard2Name") + "\t" + PlayerPrefs.GetInt("Hard2Score");
        third.text = "3rd) " + PlayerPrefs.GetString("Hard3Name") + "\t" + PlayerPrefs.GetInt("Hard3Score");
    }
}
