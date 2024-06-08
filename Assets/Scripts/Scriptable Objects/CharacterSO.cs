using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Body", menuName = "ScriptableObjects/Body")]
public class CharacterSO : ScriptableObject
{
    // Start is called before the first frame update
    public Part[] characterParts;
}
[System.Serializable]
public class Part
{
    public string partName;
    public BodyPartSO part;
}