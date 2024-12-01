using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SoundSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] Slider masterVolumeValue;
    [SerializeField] Slider musicVolumeValue;
    [SerializeField] Slider SFXVolumeValue;

    private string masterVolume = "MasterVolume";
    private string musicVolume = "MusicVolume";
    private string SFXVolume = "SFXVolume";

    private void Start()
    {
        masterVolumeValue.value = PlayerPrefs.GetFloat(masterVolume, .2f);
        musicVolumeValue.value = PlayerPrefs.GetFloat(musicVolume, .2f);
        SFXVolumeValue.value = PlayerPrefs.GetFloat(SFXVolume, .2f);
        SetMasterVolume();
        SetMusicVolume();
        SetSFXVolume();
    }

    public void SetMasterVolume()
    {
        SetVolume(masterVolume, masterVolumeValue.value);
        PlayerPrefs.SetFloat(masterVolume, masterVolumeValue.value);
    }
    public void SetMusicVolume()
    {
        SetVolume(musicVolume, musicVolumeValue.value);
        PlayerPrefs.SetFloat(musicVolume, musicVolumeValue.value);
    }
    public void SetSFXVolume()
    {
        SetVolume(SFXVolume, SFXVolumeValue.value);
        PlayerPrefs.SetFloat(SFXVolume, SFXVolumeValue.value);
    }

    void SetVolume(string groupName, float value)
    {
        float adjustedVolume = Mathf.Log10(value) * 20;
        if (value == 0)
            adjustedVolume = -80;
        audioMixer.SetFloat(groupName, adjustedVolume);
    }
}
