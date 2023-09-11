using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemSpawnManager : MonoBehaviour
{
   public GameObject[] ItemPrefabs;
   public GameObject[] PaddlePrefabs;
   public PaddleSpawnManager PdManager;
   private Transform SpawnPoint;

   private int count;

    private void Start()
    {
        count = 0;
    }
    //ItemIndex�� �������� � ������� ���� ��, PaddleIndex�� � Paddle�� �ٲ��� ����. 
    //ItemIndex 0: item_Ling 1: item_Short
    //PaddleIndex 0: Normal_Paddle 1: Long_Paddle 2: Short_Paddle
    public void SpawnPaddleItem(int ItemIndex, int PaddleIndex,Transform transform)
    {
        GameObject item= Instantiate(ItemPrefabs[ItemIndex], transform.position, Quaternion.identity);
        item.GetComponent<Item>().SetAll(PdManager, PaddlePrefabs[PaddleIndex]);
    }
    //count�� ���� � ������ ������ �� ����
    public void CalSpawn()
    {
        if(SpawnPoint == null)
        {
            Debug.Log("SpawnPoint == null");
            return;
        }
        if(count %5 == 0)
        {
            SpawnPaddleItem(0,1, SpawnPoint);
        }
        if(count %3== 0)
        {
            SpawnPaddleItem(1,2, SpawnPoint);
        }
    }
 
   public void CallBlockBreak(Transform transform)
   {
        //��� �ı� �� ��Ͽ� ���� ������ �� ������ ���´�.
        //��� �ı� �� ItemSpawnManager���� ���� �ϰ� ������ ���⿡ ������ �ȴ�.  
        SpawnPoint = transform;
        if (SpawnPoint == null)
        {
            Debug.Log("SpawnPoint == null In CallBlockBreak");
            return;
        }
        count++;
        CalSpawn();
   }
}
