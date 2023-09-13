using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestResultManager : MonoBehaviour
{
    private string keyValue;
    private string[] difficultyArr = new string[] { "Easy", "Normal", "Hard" };
    private string[] nameArr = new string[] { "쌀밥", "콩밥", "현미밥" };
    public int difficulty;
    public bool isName;

    [SerializeField] private TMP_Text first;
    [SerializeField] private TMP_Text second;
    [SerializeField] private TMP_Text third;

    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.DeleteKey("Start");
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
        if (isName == true)
        {
            if (difficulty == 1)
            {
                WriteEasyResultName();
            }

            else if (difficulty == 2)
            {
                WriteNormalResultName();
            }

            else if (difficulty == 3)
            {
                WriteHardResultName();
            }

            else if (difficulty == 4)
            {
                WriteAllResultName();
            }
        }

        if (isName == false)
        {
            if (difficulty == 1)
            {
                WriteEasyResultScore();
            }

            else if (difficulty == 2)
            {
                WriteNormalResultScore();
            }

            else if (difficulty == 3)
            {
                WriteHardResultScore();
            }

            else if (difficulty == 4)
            {
                WriteAllResultScore();
            }
        }

    }


    public void WriteEasyResultName()
    {
        first.text = PlayerPrefs.GetString("Easy1Name");
        second.text = PlayerPrefs.GetString("Easy2Name");
        third.text = PlayerPrefs.GetString("Easy3Name");
    }

    public void WriteEasyResultScore()
    {
        first.text = PlayerPrefs.GetInt("Easy1Score").ToString();
        second.text = PlayerPrefs.GetInt("Easy2Score").ToString();
        third.text = PlayerPrefs.GetInt("Easy3Score").ToString();
    }

    public void WriteNormalResultName()
    {
        first.text = PlayerPrefs.GetString("Normal1Name");
        second.text = PlayerPrefs.GetString("Normal2Name");
        third.text = PlayerPrefs.GetString("Normal3Name");
    }

    public void WriteNormalResultScore()
    {
        first.text = PlayerPrefs.GetInt("Normal1Score").ToString();
        second.text = PlayerPrefs.GetInt("Normal2Score").ToString();
        third.text = PlayerPrefs.GetInt("Normal3Score").ToString();
    }

    public void WriteHardResultName()
    {
        first.text = PlayerPrefs.GetString("Hard1Name");
        second.text = PlayerPrefs.GetString("Hard2Name");
        third.text = PlayerPrefs.GetString("Hard3Name");
    }

    public void WriteHardResultScore()
    {
        first.text = PlayerPrefs.GetInt("Hard1Score").ToString();
        second.text = PlayerPrefs.GetInt("Hard2Score").ToString();
        third.text = PlayerPrefs.GetInt("Hard3Score").ToString();
    }

    public void WriteAllResultName()
    {
        first.text = PlayerPrefs.GetString("Easy1Name");
        second.text = PlayerPrefs.GetString("Normal1Name");
        third.text = PlayerPrefs.GetString("Hard1Name");
    }

    public void WriteAllResultScore()
    {
        first.text = PlayerPrefs.GetInt("Easy1Score").ToString();
        second.text = PlayerPrefs.GetInt("Normal1Score").ToString();
        third.text = PlayerPrefs.GetInt("Hard1Score").ToString();
    }
}
