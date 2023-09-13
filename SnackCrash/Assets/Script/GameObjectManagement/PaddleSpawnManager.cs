using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PaddleSpawnManager : MonoBehaviour
{
    public GameObject PaddlePrefabBowl;
    public GameObject PaddlePrefabDish;
    public Transform SpawnPoint_Paddle;
    public Queue<GameObject> Paddle;
    public Cloud_Spear_System EnemyScript;
    public GameObject Enemy;
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
        // -- 송명근 PlayerDish에 따라 가져오는 Prefab 변경
        if (PlayerPrefs.GetInt("PlayerDish") == 1)
        {
            GameObject newPaddle = Instantiate(PaddlePrefabDish, SpawnPoint_Paddle.position, Quaternion.identity);
            Paddle.Enqueue(newPaddle);
        }

        else if (PlayerPrefs.GetInt("PlayerDish") == 2)
        {
            GameObject newPaddle = Instantiate(PaddlePrefabBowl, SpawnPoint_Paddle.position, Quaternion.identity);
            Paddle.Enqueue(newPaddle);
        }
        
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

    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(Enemy);
        EnemyScript=enemy.GetComponent<Cloud_Spear_System>();
        EnemyScript.SetManager(this);
    }

    public void SpawnPaddleDelay(float delay)
    {
        Invoke(nameof(SpawnPaddle), delay);
    }
}
