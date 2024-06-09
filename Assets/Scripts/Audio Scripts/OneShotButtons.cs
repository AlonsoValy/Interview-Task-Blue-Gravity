using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotButtons : MonoBehaviour
{
 

  
    public void play(int audioIndex)
    {
        AudioManager.instance.PlayOneshotSFX((AudioManager.AudioSamples)audioIndex);
    }
}
