using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WriteScore : MonoBehaviour
{
    public TMP_Text ScriptTxt;
    private void Start()
    {
        ScriptTxt.text = PlayerPrefs.GetInt("CurrentScore").ToString();
    }
}
