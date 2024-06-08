using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartManager : MonoBehaviour
{
    //Update Animations to match
    [SerializeField] CharacterSO character;

    [SerializeField] string[] partTypes;
    [SerializeField] string[] characterStates;
    [SerializeField] string[] Directions;

    //animation stuff, everything wrote regarding animation here was pre-written in another project
    private Animator animator;
    private AnimationClip clip;
    private AnimatorOverrideController overrideController;
    private AnimationClipOverrides defaultClips;


    private void Start()
    {
        animator = GetComponent<Animator>();
        overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = overrideController;
        defaultClips = new AnimationClipOverrides(overrideController.overridesCount);
        overrideController.GetOverrides(defaultClips);
        UpdateParts();
    }
    public void UpdateParts()
    {
        for (int index = 0; index < partTypes.Length; index++)
        {
            string partType = partTypes[index];
            string partID = character.characterParts[index].part.animationID.ToString();
            for (int StateIndex = 0; StateIndex < characterStates.Length; StateIndex++)
            {
                string state = characterStates[StateIndex];
                for (int directionIndex = 0; directionIndex < Directions.Length; directionIndex++)
                {
                    string direction = Directions[directionIndex];
                    // ***NOTE:Animation Naming Must Be: "[Type]_[Index]_[state]_[direction]" (Ex. Body_0_idle_down)
                    clip = Resources.Load<AnimationClip>("Player Animations/" + partType + "/" + partType + "_" + partID + "_" + state + "_" + direction);

                    defaultClips[partType + "_" + 0 + "_" + state + "_" + direction] = clip;
                }
            }

        }
        overrideController.ApplyOverrides(defaultClips);
    }
    
}


public class AnimationClipOverrides : List<KeyValuePair<AnimationClip, AnimationClip>>
{
    public AnimationClipOverrides(int capacity) : base(capacity) { }

    public AnimationClip this[string name]
    {
        get
        {
            return this.Find(x => x.Key.name.Equals(name)).Value;
        }
        set { int index = this.FindIndex(x =>x.Key.name.Equals(name));
        if (index != -1)
            {
                this[index] = new KeyValuePair<AnimationClip, AnimationClip>(this[index].Key, value);
            }
        }
    }

}