using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour
{
    public BlockSpawnManager blockSpawnManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            blockSpawnManager.DestroyBlock(this.gameObject);
        }
    }
    public void SetManager(BlockSpawnManager inputManager)
    {
       blockSpawnManager = inputManager;
    }
}
