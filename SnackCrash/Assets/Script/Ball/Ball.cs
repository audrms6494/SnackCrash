using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float StartPower; // 최대 속도
    private Rigidbody2D rb;

    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        if(StartPower==0)
        {
            StartPower = 10.0f;
        }
        rb.AddForce(new Vector3(0,StartPower,0));
    }

}
