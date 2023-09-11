using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private GameObject ChangePaddle;
    private PaddleSpawnManager PdManager; 
    public void SetPdManager(PaddleSpawnManager spawnManager)
    {
        PdManager = spawnManager;
    }
    public void SetPaddle(GameObject paddle)
    {
        ChangePaddle = paddle;
    }
    public void SetAll(PaddleSpawnManager manager,GameObject paddle)
    {
        SetPdManager(manager);
        SetPaddle(paddle);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            PdManager.SpawnPaddle(ChangePaddle);
            Destroy(gameObject);
        }
    }
}
