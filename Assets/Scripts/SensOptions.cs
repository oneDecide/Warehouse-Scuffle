using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensOptions : MonoBehaviour
{

    [SerializeField] private PlayerCamera pCam;

    private void Start()
    {
        float currentSensIndex = PlayerPrefs.GetFloat("SensitivityIndex", 3);
        SetSensitivity(currentSensIndex);
        
    }

    public void SetSensitivity(float value)
    {
        if(pCam != null)
            pCam.SetSens(value);
        PlayerPrefs.SetFloat("SensitivityIndex", value);
    }
}
