using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_2 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Movement_x=30.0f;
    public float Movement_y=30.0f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rb.velocity = new Vector3(Movement_x, Movement_y,0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("RightWall")|| collision.gameObject.CompareTag("LeftWall"))
        {
            Movement_x *= -1;
        }
        if (collision.gameObject.CompareTag("Top") || collision.gameObject.CompareTag("Bottom")|| collision.gameObject.CompareTag("Paddle") || collision.gameObject.CompareTag("Block"))
        {
            Movement_y *= -1;
        }
    }
}
