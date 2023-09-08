using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawnManager : MonoBehaviour
{
    public GameObject BrickPrefab;
    public Transform Spawnposition;

    void Start()
    {
        SpawnBricks(30);
    }

    public void SpawnBricks(int TotalBricks)
    {
        float distanceX = 0;
        float distanceY = 0;
        Vector3 spawnPosition;
        // TotalBricks���� BrickPrefab�� �����մϴ�.
        for (int i = 0; i < TotalBricks; i++)
        {
            if (i % 5 == 0)
            {
                // �� �ٲ�
                distanceX = 0;
                distanceY -= 0.3f ;
            }
            distanceX++;
            spawnPosition = Spawnposition.position + new Vector3(distanceX * 1.1f, distanceY, 0f);
            Instantiate(BrickPrefab, spawnPosition, Quaternion.identity);
        }
    }
}