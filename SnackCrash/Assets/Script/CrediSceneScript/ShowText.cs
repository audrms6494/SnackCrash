using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    public Text textToShow; // UI 텍스트 엘리먼트를 Inspector에서 연결
    private bool isInside = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어1 (Player1) 태그를 가진 오브젝트와 충돌하면 텍스트를 보여줍니다.
        if (other.CompareTag("Player1"))
        {
            Debug.Log("충돌 텍스트 보임");
            isInside = true;
            ShowThisText();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 트리거 영역을 벗어날 때 텍스트를 숨깁니다.
        if (other.CompareTag("Player1"))
        {
            Debug.Log("충돌 텍스트 꺼짐");

            isInside = false;
            HideText();
        }
    }

    private void ShowThisText()
    {
        textToShow.gameObject.SetActive(true);
    }

    private void HideText()
    {
        textToShow.gameObject.SetActive(false);
    }
}
