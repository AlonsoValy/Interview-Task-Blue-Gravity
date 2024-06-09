using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/ClotheItem")]
public class ClotheItemSO : ScriptableObject
{
    public string itemName;
    public int value;
    public Sprite icon;
}
