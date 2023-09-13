using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_Spear_System : MonoBehaviour
{
    public PaddleSpawnManager PSManager;
    public GameObject CandyPrefab;
    public float time = 0;
    public float delay;

    private void Update()
    {
        time += Time.deltaTime;
        if (time > delay)
        {
            time = 0;
            // -2, 0, 2 중에서 랜덤하게 x 좌표 선택
            float randomX = Random.Range(0, 3) * 2 - 2;
            Vector3 randomPosition = new Vector3(randomX, 0f, 0f);
            InstantiateCandy(randomPosition);
        }
    }

    public void SetManager(PaddleSpawnManager manager)
    {
        PSManager = manager;
    }

    private void InstantiateCandy(Vector3 position)
    {
        GameObject candy = Instantiate(CandyPrefab, position, Quaternion.identity);
        ShockItem shock = candy.GetComponent<ShockItem>();
        if (shock != null)
        {
            shock.SetManager(PSManager);
        }
    }
}
