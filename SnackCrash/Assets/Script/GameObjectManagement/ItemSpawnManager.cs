using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
   public GameObject[] ItemPrefabs;
   public GameObject[] PaddlePrefabs;
   public PaddleSpawnManager PdManager;
   public void SpawnItem(int ItemIndex, int PaddleIndex,Transform transform)
   {
        GameObject item= Instantiate(ItemPrefabs[ItemIndex], transform.position, Quaternion.identity);
        item.GetComponent<Item>().SetAll(PdManager, PaddlePrefabs[PaddleIndex]);
   } 
}
