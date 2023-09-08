using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnManager : MonoBehaviour
{
    public GameObject BallPrefab;
    public Transform SpawnPoint_Ball;

    void Start()
    {
        SpawnBall();
    }

    public void SpawnBall()
    {
        Instantiate(BallPrefab, SpawnPoint_Ball.position, Quaternion.identity);
    }

}
