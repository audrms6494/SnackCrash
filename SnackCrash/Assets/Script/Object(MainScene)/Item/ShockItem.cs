using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockItem : MonoBehaviour
{
    public PaddleSpawnManager PSManager;
    public GameObject PenaltyPaddle;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle") || collision.gameObject.CompareTag("Paddle_Low") || collision.gameObject.CompareTag("Paddle_Mid") || collision.gameObject.CompareTag("Paddle_High"))
        {
            if(PSManager != null&&PenaltyPaddle != null)
            {
                PSManager.SpawnPaddle(PenaltyPaddle);
            }
            else
            {
                Debug.Log("PSManager == null Or PenaltyPaddle == null");
            }

            Destroy(this.gameObject);
        }
    }
}
