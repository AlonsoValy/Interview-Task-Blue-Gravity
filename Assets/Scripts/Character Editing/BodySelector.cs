using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodySelector : MonoBehaviour
{

    //Handles body selector Updates
    [SerializeField] CharacterSO character;
    [SerializeField] partSelection[] partSelections;

    private void Start()
    {
        for (int i = 0; i < partSelections.Length; i++)
        {
            GetCurrentParts(i);
        }
    }
    private void GetCurrentParts(int index)
    {
        //Get name and ID for UI and anims
        partSelections[index].NamePartTextComponent.text = character.characterParts[index].part.partName;
        partSelections[index].partCurrentIndex = character.characterParts[index].part.animationID;
    }
    private void UpdatePart(int index)
    {
        //Update UI text and part in the body
        partSelections[index].NamePartTextComponent.text = partSelections[index].partOptions[partSelections[index].partCurrentIndex].partName;
        character.characterParts[index].part = partSelections[index].partOptions[partSelections[index].partCurrentIndex];
    }
    private bool Validate(int index)
    {
        if (index > partSelections.Length || index < 0)
        {
            Debug.Log("index value does not match parts");
            return false;
        }
        else
        {
            return true;
        }
    }
    public void Next(int index)
    {
        if (Validate(index))
        {
            if (partSelections[index].partCurrentIndex < partSelections[index].partOptions.Length -1)
            {
                partSelections[index].partCurrentIndex++;
            }
            else
            {
                partSelections[index].partCurrentIndex = 0;
            }
            UpdatePart(index);
        }
    }
    public void Previous(int index)
    {
        if (Validate(index))
        {
            if (partSelections[index].partCurrentIndex > 0)
            {
                partSelections[index].partCurrentIndex--;
            }
            else
            {
                partSelections[index].partCurrentIndex = partSelections[index].partOptions.Length -1;
            }
            UpdatePart(index);
        }
    }
}

[System.Serializable]
public class partSelection
{
    public string partName;
    public BodyPartSO[] partOptions;
    public Text NamePartTextComponent;
    public int partCurrentIndex;
}