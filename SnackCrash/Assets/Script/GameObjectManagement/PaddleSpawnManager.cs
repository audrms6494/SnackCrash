using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PaddleSpawnManager : MonoBehaviour
{
    public GameObject PaddlePrefab;
    public Transform SpawnPoint_Paddle;
    public Queue<GameObject> Paddle;

    void Start()
    {
        Paddle = new Queue<GameObject>(); // 큐 초기화
        SpawnPaddle();
    }

    public void SpawnPaddle()
    {
        // 이전 패들이 큐에 있을 경우 파괴
        if (Paddle.Count > 0)
        {
            GameObject previousPaddle = Paddle.Dequeue();
            Destroy(previousPaddle);
        }

        // 새 패들 생성 및 큐에 추가
        GameObject newPaddle = Instantiate(PaddlePrefab, SpawnPoint_Paddle.position, Quaternion.identity);
        Paddle.Enqueue(newPaddle);
    }
    public void SpawnPaddle(GameObject InputPaddle)
    {
        float x=0.0f;
        // 이전 패들이 큐에 있을 경우 파괴
        if (Paddle.Count > 0)
        {
            GameObject previousPaddle = Paddle.Dequeue();
            x = previousPaddle.GetComponent<Paddle>().GetPositionX();
            Destroy(previousPaddle);
        }

        // 새 패들 생성 및 큐에 추가
        GameObject newPaddle = Instantiate(InputPaddle, new Vector3(x,-4,0), Quaternion.identity);
        Paddle.Enqueue(newPaddle);
    }
}
