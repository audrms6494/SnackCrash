using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemSpawnManager : MonoBehaviour
{
   public GameObject[] ItemPrefabs;
   public GameObject[] PaddlePrefabs;
   public GameObject[] BallItemPrefabs;
   public PaddleSpawnManager PdManager;
   public BallSpawnManager BSManager;
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
        Destroy(item, 3.0f);
    }

    public void SpawnBallItem(Transform transform)
    {
        GameObject item = Instantiate(BallItemPrefabs[0], transform.position, Quaternion.identity);
        item.GetComponent<BallItem>().SetManager(BSManager);
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
        if(count ==2 ||count ==5)  SpawnBallItem(SpawnPoint);
    }
 
   public void CallBlockBreak(Transform transform)
   {
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
