using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectPaddle : MonoBehaviour
{
    public Sprite dish;
    public Sprite bowl;
    Image thisImg;

    private void Start()
    {
        PlayerPrefs.SetInt("PlayerDish", 1);
        thisImg = GetComponent<Image>();
        thisImg.sprite = dish;
    }
    public void ChangePaddle()
    {
        if (PlayerPrefs.GetInt("PlayerDish") == 1)
        {
            PlayerPrefs.SetInt("PlayerDish", 2);
            thisImg.sprite = bowl;
        }

        else if (PlayerPrefs.GetInt("PlayerDish") == 2)
        {
            PlayerPrefs.SetInt("PlayerDish", 1);
            thisImg.sprite = dish;
        }
    }

}
