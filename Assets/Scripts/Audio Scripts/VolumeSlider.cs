using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    
    private Slider slider;
    public void Start()
    {
        slider=GetComponent<Slider>();
    }
    public void setSTVol()
    {
        AudioManager.instance.ChangeVolume(slider.value,"ST");
        AudioManager.instance.TargetVolume = slider.value;
    }
    public void setSFXVol()
    {
        AudioManager.instance.ChangeVolume(slider.value, "SFX");
        AudioManager.instance.TargetVolume = slider.value;
    }
}
