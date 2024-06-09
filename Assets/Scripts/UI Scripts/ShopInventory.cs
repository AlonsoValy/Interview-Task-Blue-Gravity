using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopInventory : MonoBehaviour
{
    public List<ClotheItemSO> clotheItems = new List<ClotheItemSO>();
    public int capacity;
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] Text textToChange, dialogue;
    private void OnEnable()
    {
        textToChange.text = "Money: " + inventoryManager.moneyOnInventory.ToString() + "$";
    }
    public void substratcMoney(ClotheItemSO itemSO)
    {
        textToChange.text = "Money: " + (inventoryManager.moneyOnInventory - itemSO.value).ToString() + "$";
        inventoryManager.moneyOnInventory = inventoryManager.moneyOnInventory - itemSO.value;
    }
    public void SellItem(ClotheItemSO item)
    {
        if (inventoryManager.moneyOnInventory >= item.value)
        {
            inventoryManager.clotheItems.Add(item);
            clotheItems.Remove(item);
            substratcMoney(item);
        }
        else
        {
            dialogue.text = "You dont have enough money mate";
        }
       
    }

}
