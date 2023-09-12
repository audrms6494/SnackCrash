using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallItem : MonoBehaviour
{
    private BallSpawnManager BSManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle") || collision.gameObject.CompareTag("Paddle_Low") || collision.gameObject.CompareTag("Paddle_Mid") || collision.gameObject.CompareTag("Paddle_High"))
        {
           if(BSManager != null)
            {
                BSManager.SpawnBall(this.gameObject.transform);
            }
            Destroy(gameObject);
        }
    }

    public void SetManager(BallSpawnManager manager)
    {
        this.BSManager = manager;
    }
}
