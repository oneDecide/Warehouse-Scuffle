using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PercentageSlider : MonoBehaviour
{
    [SerializeField] private Slider ourSlider;
    [SerializeField] private TextMeshProUGUI percentageText;

    private void Start()
    {
        SetPercentage();
    }

    public void SetPercentage()
    {
        percentageText.text = (ourSlider.value * 100).ToString("F0") + "%";
    }
}
