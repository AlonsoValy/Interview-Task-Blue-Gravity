using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int moneyOnInventory;
    [SerializeField] Text textToChange;

    public void addMoney(ClotheItemSO itemSO)
    {
        textToChange.text = "Money: " + moneyOnInventory.ToString() + itemSO.value.ToString();
    }
}
