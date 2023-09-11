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
    //ItemIndex는 아이템이 어떤 모양으로 나올 지, PaddleIndex는 어떤 Paddle로 바꿀지 지정. 
    //ItemIndex 0: item_Ling 1: item_Short
    //PaddleIndex 0: Normal_Paddle 1: Long_Paddle 2: Short_Paddle
    public void SpawnPaddleItem(int ItemIndex, int PaddleIndex,Transform transform)
    {
        GameObject item= Instantiate(ItemPrefabs[ItemIndex], transform.position, Quaternion.identity);
        item.GetComponent<Item>().SetAll(PdManager, PaddlePrefabs[PaddleIndex]);
    }
    //count에 따라 어떤 아이템 스폰할 지 선택
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
        //블록 파괴 시 블록에 대한 정보가 이 곳으로 들어온다.
        //블록 파괴 시 ItemSpawnManager에서 무언가 하고 싶으면 여기에 넣으면 된다.  
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
