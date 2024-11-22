using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenSettings : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        Resolution currentResolution = Screen.currentResolution;
        int currentResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", resolutions.Length - 1);
        for (int i = resolutions.Length-1; i >= 0; i--)
        {
            string resolutionString = resolutions[i].width.ToString() + "x" + resolutions[i].height.ToString();
            resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(resolutionString));
            
        }
        currentResolutionIndex = Math.Min(currentResolutionIndex, resolutions.Length - 1);
        resolutionDropdown.value = currentResolutionIndex;
        SetResolution();
    }

    public void SetResolution()
    {
        int resIndex = resolutionDropdown.value;
        Screen.SetResolution(resolutions[resIndex].width, resolutions[resIndex].height, true);
        PlayerPrefs.SetInt("ResolutionIndex", resolutionDropdown.value);
    }
}
