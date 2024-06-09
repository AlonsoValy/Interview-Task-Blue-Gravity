using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    //All of this script it's imported, from a project made in the GGJam 2024, and slightly modified
    [SerializeField] SounDataBank soundDB;
    [SerializeField] float FadeTime, TargetVolume;
    public SounDataBank AudioDataBank => soundDB;
    public AudioMixer Mixer;
    public AudioSource SFXSource, musicSource;
    public static AudioManager instance = null;
    public enum AudioSamples
    {
        mainMenuTheme = 0, shopTheme = 1, itemSold = 2, itemBought = 3, shopKeeperHum = 4, steps = 5, buttonPressOne = 6,
        buttonPressTwo = 7
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    public static IEnumerator StartFadeMixer(AudioMixer mixer, string exposedGroup, float fadeTime, float targetVolume)
    {
        float currentTime = 0;
        float currentVol;
        mixer.GetFloat(exposedGroup, out currentVol);
        currentVol = Mathf.Pow(10, currentVol / 20);
        float targetValue = Mathf.Clamp(targetVolume, 0.0001f, 1);

        while (currentTime < fadeTime)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / fadeTime);
            mixer.SetFloat(exposedGroup, Mathf.Log10(newVol) * 20);
            yield return null;
        }
        yield break;
    }
    public void ChangeVolume(float targetVolume, string exposedMixedGroup)
    {
        Mixer.SetFloat(exposedMixedGroup, Mathf.Log10(targetVolume) * 20);
    }
    public void PlayOneshotSFX(AudioSamples sample)
    {
        SFXSource.PlayOneShot(soundDB.GetFromDataBank(sample));
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        switch (scene.buildIndex)
        {
            case 0:
                StartCoroutine(StartFadeMixer(Mixer, "ST", FadeTime, TargetVolume));
                PlayMusic(AudioSamples.mainMenuTheme);
                break;
            case 1:
                StartCoroutine(StartFadeMixer(Mixer, "ST", FadeTime, TargetVolume));
                PlayMusic(AudioSamples.shopTheme);
                break;
            default:
                break;
        }
    }
    public void PlayMusic(AudioSamples sample)
    {
        musicSource.clip = soundDB.GetFromDataBank(sample);
        musicSource.Play();
    }
}
