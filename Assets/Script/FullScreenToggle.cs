using UnityEngine;

public class FullscreenToggle : MonoBehaviour
{
    // Toggle full screen state on button click
    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
