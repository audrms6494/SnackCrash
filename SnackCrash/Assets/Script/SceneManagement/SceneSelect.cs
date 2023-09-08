using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{
    public void MoveToStart()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void MoveToMain()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void MoveToSelect()
    {
        SceneManager.LoadScene("SelectScene");
    }

    public void MoveToResult()
    {
        SceneManager.LoadScene("ResultScene");
    }
    public void MoveToCredit()
    {
        SceneManager.LoadScene("CreditScene");
    }

}
