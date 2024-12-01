using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenSettings : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private Toggle fullScreenToggle;
    [SerializeField] private Toggle vSyncToggle;
    private Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        int currentResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", resolutions.Length - 1);
        int currentQualityIndex = PlayerPrefs.GetInt("QualityIndex", 5);
        int currentFullScreenBool = PlayerPrefs.GetInt("FullScreenIndex", 1);
        int currentVSyncIndes = PlayerPrefs.GetInt("VsyncIndex", 1);
        for (int i = 0; i < resolutions.Length; i++)
        {
                string resolutionString = resolutions[i].width + "x" + resolutions[i].height;
                resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(resolutionString));
        }
        
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        SetResolution(currentResolutionIndex);
        qualityDropdown.value = currentQualityIndex;
        if (currentFullScreenBool == 1)
        {
            fullScreenToggle.isOn = true;
            SetFullScreen(true);
        }
        else
        {
            fullScreenToggle.isOn = false;
            SetFullScreen(false);
        }
        SetQuality(currentQualityIndex);
        if (currentVSyncIndes == 1)
        {
            setVSync(true);
            vSyncToggle.isOn = true;
        }
        else
        {
            setVSync(false);
            vSyncToggle.isOn = false;
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resoluton = resolutions[resolutionIndex];
        Screen.SetResolution(resoluton.width, resoluton.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("QualityIndex", qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        PlayerPrefs.SetInt("FullScreenIndex", isFullScreen ? 1 : 0);
    }

    public void setVSync(bool vSyncOn)
    {
        QualitySettings.vSyncCount = vSyncOn ? 1 : 0;
        PlayerPrefs.SetInt("VsyncIndex", vSyncOn ? 1 : 0);
    }
}
