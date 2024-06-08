using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BodyPart", menuName ="ScriptableObjects/Bodypart")]
public class BodyPartSO : ScriptableObject
{
    public string partName;
    public int animationID;
    public List<AnimationClip> partAnimations;

}
