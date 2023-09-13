using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WriteResultManager : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    private string playerName = null;
    private int currentScore;

    // PlayerPrefs key value 생성
    private int playerLevel;
    private string opponentName;
    private string opponentScore;
    private string difficulty;

    private string tempKey1;
    private string tempKey2;
    private string tempName;
    private int tempScore;

    private void Start()
    {
        currentScore = PlayerPrefs.GetInt("CurrentScore");
        playerLevel = PlayerPrefs.GetInt("playerLevel");
        switch (playerLevel)
        {
            case 1:
                difficulty = "Easy";
                break;
            case 2:
                difficulty = "Normal";
                break;
            case 3:
                difficulty = "Hard";
                break;
        }
    }
    public void SaveResult()
    {
        playerName = playerNameInput.text;
        for (int i = 1; i <= 3; i++)
        {
            opponentName = difficulty + i.ToString() + "Name";
            opponentScore = difficulty + i.ToString() + "Score";
            if (currentScore > PlayerPrefs.GetInt(opponentScore))
            {
                for (int j = 3; j > i; j--)
                {
                    tempKey1 = difficulty + j.ToString() + "Name"; // 밀어낼 등수
                    tempKey2 = difficulty + (j-1).ToString() + "Name"; // 들어가는 등수
                    tempName = PlayerPrefs.GetString(tempKey2);
                    PlayerPrefs.SetString(tempKey1, tempName);
                    tempKey1 = difficulty + j.ToString() + "Score"; // 밀어낼 등수
                    tempKey2 = difficulty + (j-1).ToString() + "Score"; // 들어가는 등수
                    tempScore = PlayerPrefs.GetInt(tempKey2);
                    PlayerPrefs.SetInt(tempKey1, tempScore);
                }
                PlayerPrefs.SetString(opponentName, playerName);
                PlayerPrefs.SetInt(opponentScore, currentScore);
                break; // 기입완료 및 탈출
            }
        }
    }
}
