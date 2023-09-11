using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_2 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Movement_x=30.0f;
    public float Movement_y=30.0f;
    public float time =0;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        time += Time.deltaTime;
        rb.velocity = new Vector3(Movement_x, Movement_y,0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RightWall") || collision.gameObject.CompareTag("LeftWall"))
        {
            Movement_x *= -1;
        }
        else if (collision.gameObject.CompareTag("Top") || collision.gameObject.CompareTag("Bottom") || collision.gameObject.CompareTag("Paddle") || collision.gameObject.CompareTag("Block"))
        {
            Movement_y *= -1;
        }else if (time < 0.1f)
        {
            return;
        }
        else if (collision.gameObject.CompareTag("Paddle_Low"))
        {
            float sign = Mathf.Sign(Movement_x);
            float angleInRadians = 45f * Mathf.Deg2Rad;
            float speed = Mathf.Sqrt(Movement_x * Movement_x + Movement_y * Movement_y);
            Movement_x = speed * Mathf.Cos(angleInRadians)*sign;
            Movement_y = speed * Mathf.Sin(angleInRadians);
            time = 0;
        }
        else if (collision.gameObject.CompareTag("Paddle_High"))
        {
            float sign = Mathf.Sign(Movement_x);
            float angleInRadians = 75f * Mathf.Deg2Rad;
            float speed = Mathf.Sqrt(Movement_x * Movement_x + Movement_y * Movement_y);
            Movement_x = speed * Mathf.Cos(angleInRadians) * sign;
            Movement_y = speed * Mathf.Sin(angleInRadians);
        }
        else if (collision.gameObject.CompareTag("Paddle_Mid"))
        {
            Movement_y *= -1;
            time = 0;
        }
        else
        {
            // 다른 태그에 대한 처리
        }


    }
}
