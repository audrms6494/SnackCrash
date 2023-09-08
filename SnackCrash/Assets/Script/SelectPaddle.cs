using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectPaddle : MonoBehaviour
{
    public Image PaddleImage;
    public Sprite[] PaddleSprites;
    private int currentPaddle = 0;  
     
    public void selectPaddle()
    {
        currentPaddle = (currentPaddle + 1) % PaddleSprites.Length;
        UpdatePaddleImage();
    }

    public void GameStart()
    {
        string selectedPaddle = PaddleSprites[currentPaddle].name;
        PlayerPrefs.SetString("SelectedCharacter", selectedPaddle);
    }

    private void UpdatePaddleImage()
    {
        PaddleImage.sprite = PaddleSprites[currentPaddle];
    }

}
