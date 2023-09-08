using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public Image soundImage;
    public Sprite SoundOn;
    public Sprite SoundOff;

    private bool isSoundPlaying = true;

    void Start()
    {

    }

    public void SoundControl()
    {
        if (isSoundPlaying)
        {
            audioSource.Stop();

        }
        else
        {
            audioSource.Play();
        }

        isSoundPlaying = !isSoundPlaying; // 상태를 반전시킴

        // 상태 변경 후 이미지 업데이트
        SoundOnOffImage();
    }

    private void SoundOnOffImage()
    {
        if (isSoundPlaying)
        {
            soundImage.sprite = SoundOn;
        }
        else
        {
            soundImage.sprite = SoundOff;
        }
    }
}
