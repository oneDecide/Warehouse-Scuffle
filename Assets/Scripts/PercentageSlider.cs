using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PercentageSlider : MonoBehaviour
{
    [SerializeField] private Slider ourSlider;
    [SerializeField] private TextMeshProUGUI percentageText;

    public void SetPercentage()
    {
        percentageText.text = (ourSlider.value * 100).ToString("F0") + "%";
    }
}
