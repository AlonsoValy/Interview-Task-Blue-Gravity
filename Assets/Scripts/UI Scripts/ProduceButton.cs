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
    [SerializeField] List<GameObject> inButtons;
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
        GameObject template = transform.GetChild(0).gameObject;
        template.SetActive(true);
        GameObject It;

        foreach (var item in inventoryManager.clotheItems)
        {

            It = Instantiate(template, transform);
            It.transform.GetChild(0).GetComponent<Image>().sprite = item.icon;
            It.transform.GetChild(1).GetComponent<Text>().text = item.itemName;
            It.transform.GetChild(2).GetComponent<Text>().text = item.value.ToString() + "$";
            It.GetComponent<Button>().AddEventListener(item, inventoryManager.RemoveItem);
            inButtons.Add(It);
        }
        template.SetActive(false);
    }
}
