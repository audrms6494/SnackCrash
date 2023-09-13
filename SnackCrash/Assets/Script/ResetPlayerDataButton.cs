using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerDataButton : MonoBehaviour
{
    public void ResetPlayerPreferences()
    {
        PlayerPrefs.DeleteKey("playerLevel");
        PlayerPrefs.DeleteKey("stageLevel");
    }
}
