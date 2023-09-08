using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSpawnManager : MonoBehaviour
{
    public GameObject PaddlePrefab;
    public Transform SpawnPoint_Paddle;
    public Queue<GameObject> Paddle;

    void Start()
    {
        Paddle = new Queue<GameObject>(); // ť �ʱ�ȭ
        SpawnPaddle();
    }

    public void SpawnPaddle()
    {
        // ���� �е��� ť�� ���� ��� �ı�
        if (Paddle.Count > 0)
        {
            GameObject previousPaddle = Paddle.Dequeue();
            Destroy(previousPaddle);
        }

        // �� �е� ���� �� ť�� �߰�
        GameObject newPaddle = Instantiate(PaddlePrefab, SpawnPoint_Paddle.position, Quaternion.identity);
        Paddle.Enqueue(newPaddle);
    }
}
