using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSpawnManager : MonoBehaviour
{
    public GameObject PaddlePrefab;
    public Transform SpawnPoint_Paddle;
    void Start()
    {
        SpawnPaddle();
    }
 
    public void SpawnPaddle()
    {
        Instantiate(PaddlePrefab, SpawnPoint_Paddle.position, Quaternion.identity);
    }

}
