using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float maxSpeed; // �ִ� �ӵ�
    private Rigidbody2D rb;

    private void Start()
    {
     rb= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //���� �ӵ�
        Vector2 velocity = rb.velocity;
        //���� �ӵ��� ũ��
        float CuSpeed = velocity.magnitude;
        if(CuSpeed > maxSpeed)
        {
            //���� �ӵ��� normalized �ؼ� ���⸸ ������ �� maxSpeed�� ����.
            velocity = velocity.normalized * maxSpeed;
            rb.velocity = velocity;
        }
    }
}
