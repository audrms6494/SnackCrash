using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOnOff : MonoBehaviour
{
    [SerializeField] private GameObject inputUI;
    public void OnOffObject()
    {
        if (inputUI.activeSelf == true)
        {
            inputUI.SetActive(false);
        }
        else
        {
            inputUI.SetActive(true);
        }
    }
}
