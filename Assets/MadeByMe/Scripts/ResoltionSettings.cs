using UnityEngine;
using TMPro;

public class ResoltionSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Sets the target frame rate of the game to 60 fps
        Application.targetFrameRate = 60;

        //Sets the resolution to 1080p as a base
        Screen.SetResolution(Screen.width, Screen.height,Screen.fullScreenMode);
    }

    /// <summary>
    /// Changed the resolution of the game
    /// </summary>
    /// <param name="newResolution"></param>
    public void ChangeResolution(TMP_Dropdown newResolution)
    {
        //0 sets the screen to 1080p, 1 sets the screen to 1440p and 2 sets the screen to 4k
        switch (newResolution.value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, Screen.fullScreenMode);
                break;
            case 1:
                Screen.SetResolution(2560, 1440, Screen.fullScreenMode);
                break;
            case 2:
                Screen.SetResolution(3840, 2160, Screen.fullScreenMode);
                break;
        }
    }

    /// <summary>
    /// Changes the window type between borderless full screen and windowed
    /// </summary>
    /// <param name="toggle"></param>
    public void ToggleFullScreen(TMP_Dropdown toggle)
    {
        switch (toggle.value)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
        }
    }
}
