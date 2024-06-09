using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
  public List<ClotheItemSO> clotheItems = new List<ClotheItemSO>();
  public int capacity;

    public void AddItem(ClotheItemSO item)
    {
        clotheItems.Add(item);
    }
    public void RemoveItem(ClotheItemSO item)
    {
        clotheItems.Remove(item);
    }

}
