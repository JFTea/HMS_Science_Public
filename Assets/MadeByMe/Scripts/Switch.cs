using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    /// <summary>
    /// Private reference to the boolean that controls whether the button is on or off
    /// </summary>
    public bool isOn = false;

    public bool canSwitch = true;

    /// <summary>
    /// The event triggered when the switch is turned on
    /// </summary>
    public UnityEvent switchOn;

    /// <summary>
    /// The event triggered when the switch is turned off
    /// </summary>
    public UnityEvent switchOff;

    /// <summary>
    /// Private reference to the animator controlling switch visuals
    /// </summary>
    [SerializeField]
    private Animator animator;

    /// <summary>
    /// Private reference to the prompt for interaction
    /// </summary>
    [SerializeField]
    private Canvas promptCanvas;

    /// <summary>
    /// A boolean that checks to see if the player is near the switch
    /// </summary>
    private bool nearSwitch = false;

    /// <summary>
    /// Private reference to the player gameobject
    /// </summary>
    private GameObject player;

    /// <summary>
    /// Private reference to the volume control gameobject
    /// </summary>
    private GameObject volumeControl;

    // Start is called before the first frame update
    void Start()
    {
        CheckState();
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<TimeTravel>().changeTime.AddListener(CheckState);

        volumeControl = GameObject.FindGameObjectWithTag("SoundEffectSettings");
        if (volumeControl != null )
        volumeControl.GetComponent<Slider>().onValueChanged.AddListener(UpdateAudio);
    }

    private void Update()
    {
        //If the player is near the switch and the switch is active the player can interact with it with E
        if (Input.GetKeyDown(KeyCode.E) && nearSwitch && canSwitch)
        {
            GetComponent<AudioSource>().Play();
            ToggleSwitch();
        }
    }

    /// <summary>
    /// Updates the sound effect volume when the volume settings changed
    /// </summary>
    /// <param name="value"></param>
    void UpdateAudio(float value)
    {
        GetComponent<AudioSource>().volume = value;
    }

    /// <summary>
    /// Checks the current state of the switch
    /// </summary>
    public void CheckState()
    {
        if (!isOn)
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the player is near the switch then nearSwitch is true and the prompt is visible
        if (other.gameObject.tag == "Player")
        {
            nearSwitch = true;
            promptCanvas.GetComponent<Canvas>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //If the player is near the switch then nearSwitch is false and the prompt is disabled
        if (other.gameObject.tag == "Player")
        {
            nearSwitch = false;
            promptCanvas.GetComponent<Canvas>().enabled = false;
        }
    }

    /// <summary>
    /// Toggles the switch on and off
    /// </summary>
    private void ToggleSwitch()
    {
        if (isOn)
        {
            TurnOff();
            switchOff.Invoke();
        }
        else if(!isOn)
        {
            TurnOn();
            switchOn.Invoke();
        }
    }

    /// <summary>
    /// Turns the switch on
    /// </summary>
    public void TurnOn()
    {
        isOn = true;
        animator.SetTrigger("On");
    }

    /// <summary>
    /// Turns the switch off
    /// </summary>
    public void TurnOff()
    {
        isOn = false;
        animator.SetTrigger("Off");
    }
}
