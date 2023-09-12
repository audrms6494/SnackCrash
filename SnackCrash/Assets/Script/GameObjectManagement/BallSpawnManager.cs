using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnManager : MonoBehaviour
{
    public MainSceneManager MainSceneManager;
    public GameObject[] BallPrefab;
    public List<GameObject> Balls;
    public Transform SpawnPoint_Ball;
    public bool BallisZero=false;
   
    void Start()
    {
       
    }

    public void SpawnBall_velocity()
    {
        BallisZero = false;
        GameObject ball= Instantiate(BallPrefab[1], SpawnPoint_Ball.position, Quaternion.identity);
        Balls.Add(ball);
    }
    public void SpawnBall()
    {
        BallisZero = false;
        GameObject ball = Instantiate(BallPrefab[0], SpawnPoint_Ball.position, Quaternion.identity);
        Balls.Add(ball);
    }
    public bool CheckBalIisZero()
    {
        if(Balls.Count == 0)
        {
            return true;
        }
        return false;
    }

    public void DestroyBall(GameObject ball)
    {
        if (ball != null && Balls.Contains(ball))
        {
            Balls.Remove(ball);
            Destroy(ball);
        }
        BallisZero=CheckBalIisZero();
        MainSceneManager.CheckGameOver(BallisZero);
    }
}
