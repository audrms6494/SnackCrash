using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WriteCurrentScore : MonoBehaviour
{
    public TMP_Text ScriptTxt;
    // Start is called before the first frame update
    void Start()
    {
        ScriptTxt.text = $"Current Score : {PlayerPrefs.GetInt("CurrentScore")}";
    }
}
