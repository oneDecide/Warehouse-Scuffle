using UnityEngine;
using UnityEngine.UI;

public class ClickSound : MonoBehaviour
{
    public AudioSource audioSource; // Single AudioSource for all sounds.

    [Range(0.8f, 1.2f)] public float minPitch = 0.9f; // Minimum pitch.
    [Range(0.8f, 1.2f)] public float maxPitch = 1.1f; // Maximum pitch.

    void Start()
    {
        // Find all buttons, sliders, and dropdowns in the scene
        foreach (Button button in FindObjectsOfType<Button>())
        {
            button.onClick.AddListener(PlaySoundWithRandomPitch);
        }

        foreach (Slider slider in FindObjectsOfType<Slider>())
        {
            slider.onValueChanged.AddListener((value) => PlaySoundWithRandomPitch());
        }

        foreach (Dropdown dropdown in FindObjectsOfType<Dropdown>())
        {
            dropdown.onValueChanged.AddListener((value) => PlaySoundWithRandomPitch());
        }
    }

    private void PlaySoundWithRandomPitch()
    {
        if (audioSource != null)
        {
            audioSource.pitch = Random.Range(minPitch, maxPitch); // Randomize pitch
            audioSource.Play(); // Play the currently assigned sound
        }
    }
}
