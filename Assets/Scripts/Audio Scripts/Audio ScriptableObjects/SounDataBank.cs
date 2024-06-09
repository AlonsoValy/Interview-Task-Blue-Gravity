using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundDatabase", menuName = "ScriptableObjects/AudioCloud")]
public class SounDataBank : ScriptableObject
{
    [SerializeField] AudioClip MainTheme = default;
    [SerializeField] AudioClip ShopTheme = default;
    [SerializeField] AudioClip ItemSold = default;
    [SerializeField] AudioClip ItemBought = default;
    [SerializeField] AudioClip ShopHum = default;
    [SerializeField] AudioClip Steps = default;
    [SerializeField] AudioClip Button1 = default;
    [SerializeField] AudioClip Button2 = default;
    [SerializeField] AudioClip DefaultSound = default;



    public AudioClip GetFromDataBank(AudioManager.AudioSamples samples) => samples switch
    {
        AudioManager.AudioSamples.mainMenuTheme => MainTheme,
        AudioManager.AudioSamples.shopTheme => ShopTheme,
        AudioManager.AudioSamples.shopKeeperHum => ShopHum,
        AudioManager.AudioSamples.itemSold => ItemSold,
        AudioManager.AudioSamples.itemBought => ItemBought,
        AudioManager.AudioSamples.steps => Steps,
        AudioManager.AudioSamples.buttonPressOne => Button1,
        AudioManager.AudioSamples.buttonPressTwo => Button2,
        _ => DefaultSound

    };
        
}
