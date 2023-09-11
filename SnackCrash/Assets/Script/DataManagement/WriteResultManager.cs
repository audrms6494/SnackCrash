using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WriteResultManager : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    private string playerName = null;
    private int playerScore = 40; // 받아올 예정
    // private int playerScore = PlayerPrefs.GetInt("CurrentScore");

    // PlayerPrefs key value 생성
    private string difficulty = "Easy"; // 받아올 예정
    // private string difficulty = PlayerPrefs.GetString("CurrentDifficulty");
    private string opponentKey;

    private string tempKey1;
    private string tempKey2;
    private string tempName;
    private int tempScore;
    public void SaveResult()
    {
        playerName = playerNameInput.text;
        for (int i = 1; i <= 3; i++)
        {
            opponentKey = difficulty + i.ToString() + "Name";
            if (playerScore > PlayerPrefs.GetInt(opponentKey))
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
                PlayerPrefs.SetString(opponentKey, playerName);
                opponentKey = difficulty + i.ToString() + "Score";
                PlayerPrefs.SetInt(opponentKey, playerScore);
                break; // 기입완료 및 탈출
            }
        }
    }
}
