using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeManager : MonoBehaviour
{
    /// <summary>
    /// Private reference to the volume control gameobject
    /// </summary>
    private GameObject volumeControl;

    // Start is called before the first frame update
    void Start()
    {
        //Finds the volume control object
        volumeControl = GameObject.FindGameObjectWithTag("MusicSettings");
        //Adds a listener to the onValueChanged event
        if(volumeControl != null )
        volumeControl.GetComponent<Slider>().onValueChanged.AddListener(UpdateAudio);
    }

    /// <summary>
    /// Updates the volume of any music audio sources 
    /// </summary>
    /// <param name="value"></param>
    void UpdateAudio(float value)
    {
        GetComponent<AudioSource>().volume = value;
    }
}
