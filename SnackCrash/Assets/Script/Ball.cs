using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float maxSpeed; // 최대 속도
    private Rigidbody2D rb;

    private void Start()
    {
     rb= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //현재 속도
        Vector2 velocity = rb.velocity;
        //현재 속도의 크기
        float CuSpeed = velocity.magnitude;
        if(CuSpeed > maxSpeed)
        {
            //현재 속도에 normalized 해서 방향만 가져온 뒤 maxSpeed로 설정.
            velocity = velocity.normalized * maxSpeed;
            rb.velocity = velocity;
        }
    }
}
