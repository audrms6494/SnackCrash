using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockItem : MonoBehaviour
{
    public PaddleSpawnManager PSManager;
    public GameObject PenaltyPaddle;
    public Rigidbody2D rb;

    private bool hasCollided = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(DropAfterDelay(1.0f)); // 1초 후에 떨어지도록 함
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasCollided) return; // 이미 충돌 처리를 한 경우 더 이상 처리하지 않음

        if (collision.gameObject.CompareTag("Paddle") || collision.gameObject.CompareTag("Paddle_Low") || collision.gameObject.CompareTag("Paddle_Mid") || collision.gameObject.CompareTag("Paddle_High"))
        {
            hasCollided = true;

            if (PSManager != null && PenaltyPaddle != null)
            {
                PSManager.SpawnPaddle(PenaltyPaddle);
                PSManager.SpawnPaddleDelay(1.0f);
                Destroy(this.gameObject);
            }
            else
            {
                if (PSManager != null)
                {
                    Debug.Log("PSManager == null");
                }
                if (PenaltyPaddle == null)
                {
                    Debug.Log("PenaltyPaddle == null");
                }
            }
        }
    }

    public void SetManager(PaddleSpawnManager manager)
    {
        PSManager = manager;
    }

    private IEnumerator DropAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        rb.gravityScale = 1.0f;
    }
}
