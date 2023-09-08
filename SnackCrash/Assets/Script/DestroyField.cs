using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyField : MonoBehaviour
{
    public BallSpawnManager BallSpawnManager;

    private void Start()
    {
        if(BallSpawnManager == null)
        {
            BallSpawnManager = GameObject.FindObjectOfType<BallSpawnManager>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            BallSpawnManager.DestroyBall(collision.gameObject);
        }
    }
}
