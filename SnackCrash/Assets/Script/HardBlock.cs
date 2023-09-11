using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HardBlock : MonoBehaviour
{
    public int Hp=2;
    public Sprite[] sprites;
    private SpriteRenderer SpriteRenderer;
    public BlockSpawnManager blockSpawnManager;

    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Hp--;
            SpriteRenderer.sprite = sprites[0];
            if (Hp == 0) blockSpawnManager.DestroyBlock(this.gameObject);
        }
    }
    public void SetManager(BlockSpawnManager inputManager)
    {
       blockSpawnManager = inputManager;
    }
}
