using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScenePaddleImage : MonoBehaviour
{
    public Image PaddleImage;

    void Start()
    {
        string selectedPaddle = PlayerPrefs.GetString("SelectedPaddle");
        Sprite selectedSprite = Resources.Load<Sprite>(selectedPaddle);
        if (selectedSprite != null)
        {
            PaddleImage.sprite = selectedSprite;
        }
    }
}
