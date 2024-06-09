using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public static class ButtonExtension
{
    public static void AddEventListener<T>(this Button button, T param, Action<T> OnClick)
    {
        button.onClick.AddListener(delegate () {  OnClick(param); });
    }
}
public class ProduceButton : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] ShopInventory shopManager;
    [SerializeField] List<GameObject> inButtons;
    GameObject It;
    private void OnEnable()
    {
        UpDatePanel();
    }
    private void OnDisable()
    {
      foreach (var button in inButtons)
        {
            Destroy(button);
        }
    }
    private void UpDatePanel()
    {
        if (inventoryManager != null)
        {
            GameObject template = transform.GetChild(0).gameObject;
            template.SetActive(true);


            foreach (var item in inventoryManager.clotheItems)
            {

                It = Instantiate(template, transform);
                It.transform.GetChild(0).GetComponent<Image>().sprite = item.icon;
                It.transform.GetChild(1).GetComponent<Text>().text = item.itemName;
                It.transform.GetChild(2).GetComponent<Text>().text = item.value.ToString() + "$";
                It.GetComponent<Button>().AddEventListener(item, inventoryManager.SellItem);
                It.GetComponent<Button>().onClick.AddListener(cleanPanel);

                It.GetComponent<Button>().onClick.AddListener(UpDatePanel);

                inButtons.Add(It);
            }
            template.SetActive(false);
        }
        else
        {
            GameObject template = transform.GetChild(0).gameObject;
            template.SetActive(true);


            foreach (var item in shopManager.clotheItems)
            {

                It = Instantiate(template, transform);
                It.transform.GetChild(0).GetComponent<Image>().sprite = item.icon;
                It.transform.GetChild(1).GetComponent<Text>().text = item.itemName;
                It.transform.GetChild(2).GetComponent<Text>().text = item.value.ToString() + "$";
                It.GetComponent<Button>().AddEventListener(item, shopManager.SellItem);
                It.GetComponent<Button>().onClick.AddListener(cleanPanel);

                It.GetComponent<Button>().onClick.AddListener(UpDatePanel);

                inButtons.Add(It);
            }
            template.SetActive(false);
        }
       
    }

    private void cleanPanel()
    {
        foreach (var button in inButtons)
        {
            Destroy(button);
        }

    }

}
