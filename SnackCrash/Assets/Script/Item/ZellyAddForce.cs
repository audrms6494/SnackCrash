using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ZellyAddForce : MonoBehaviour
{
    private Rigidbody2D rb;
    public float xPower;
    public float yPower;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
       Vector3 Power = new Vector3(xPower, yPower,0);
       rb.AddForce(Power);
    }

}
