using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class AdjustBrightness : MonoBehaviour
{
    public Slider brightnessSlider;
    public PostProcessProfile brightness;
    public PostProcessLayer layer;

    private AutoExposure exposure;

    private void Start()
    {
        float currentBrightnessIndex = PlayerPrefs.GetFloat("BrightnessIndex", 1);
        brightness.TryGetSettings(out exposure);
        brightnessSlider.value = currentBrightnessIndex;
        SetBrightness(brightnessSlider.value);
    }

    public void SetBrightness(float value)
    {
        PlayerPrefs.SetFloat("BrightnessIndex", value);
        if (value != 0 )
        {
            exposure.keyValue.value = value;
        }
        else
        {
            exposure.keyValue.value = .1f;
        }
    }
}
