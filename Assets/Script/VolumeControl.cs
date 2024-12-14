using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    void Start()
    {
        // Set the initial volume value based on Player Prefs or default to 1.0
        float initialVolume = PlayerPrefs.GetFloat("volume", 1.0f);
        volumeSlider.value = initialVolume;
        SetVolume(initialVolume);
    }

    // Update is called once per frame
    void Update()
    {
        // You can add other audio-related logic here if needed
    }

    public void AdjustVolume(float volume)
    {
        SetVolume(volume);
        PlayerPrefs.SetFloat("volume", volume);
    }

    private void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }
}
