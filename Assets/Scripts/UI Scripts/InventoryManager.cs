using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
  public List<ClotheItemSO> clotheItems = new List<ClotheItemSO>();
  public int capacity;
  public int moneyOnInventory;
  [SerializeField] ShopInventory shop;
  [SerializeField] Text textToChange;
    private void OnEnable()
    {
        textToChange.text = "Money: " + moneyOnInventory.ToString() + "$";
    }
    public void addMoney(ClotheItemSO itemSO)
    {
        textToChange.text = "Money: " + (moneyOnInventory + itemSO.value).ToString() + "$";
        moneyOnInventory = moneyOnInventory + itemSO.value;
    }
    public void SellItem(ClotheItemSO item)
    {
        shop.clotheItems.Add(item);
        clotheItems.Remove(item);
        addMoney(item);
    }

}
