using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensOptions : MonoBehaviour
{
    [SerializeField] public Slider ourSlider;
    
    [SerializeField] private PlayerCamera pCam;
    

    private void Start()
    {
        float currentSensIndex = PlayerPrefs.GetFloat("SensitivityIndex", 3);
        SetSensitivity(currentSensIndex);
        ourSlider.value = currentSensIndex;
    }

    public void SetSensitivity(float value)
    {
        if(pCam != null)
            pCam.SetSens(value);
        ourSlider.value = value;
        PlayerPrefs.SetFloat("SensitivityIndex", value);
    }
}
