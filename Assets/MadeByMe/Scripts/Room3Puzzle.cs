using UnityEngine;

public class Room3Puzzle : MonoBehaviour
{
    /// <summary>
    /// Private reference to the present version of this room
    /// </summary>
    [SerializeField]
    private GameObject roomPresent;

    /// <summary>
    /// Private reference to the future version of this room
    /// </summary>
    [SerializeField]
    private GameObject roomFuture;

    /// <summary>
    /// Private reference to the room4Key gameobject
    /// </summary>
    [SerializeField]
    private GameObject room4Key;

    /// <summary>
    /// Private reference to the animation that makes the glass rise up
    /// </summary>
    [SerializeField]
    private Animation glassBoxAnimation;

    /// <summary>
    /// Private reference to the first puzzle switch
    /// </summary>
    [SerializeField]
    private GameObject switch1;

    /// <summary>
    /// Private reference to the tracker bool of the second switch
    /// </summary>
    private bool switch1Active;

    /// <summary>
    /// Private reference to the second puzzle switch
    /// </summary>
    [SerializeField]
    private GameObject switch2;

    /// <summary>
    /// Private reference to the tracker bool of the second switch
    /// </summary>
    private bool switch2Active;

    /// <summary>
    /// Private reference to the third puzzle switch
    /// </summary>
    [SerializeField]
    private GameObject switch3;

    /// <summary>
    /// Private reference to the first hint switch
    /// </summary>
    [SerializeField]
    private GameObject hintSwitch1;

    /// <summary>
    /// Private reference to the second hint switch
    /// </summary>
    [SerializeField]
    private GameObject hintSwitch2;

    /// <summary>
    /// Private reference to the third hint switch
    /// </summary>
    [SerializeField]
    private GameObject hintSwitch3;

    /// <summary>
    /// Private reference to the medical log gameobject
    /// </summary>
    [SerializeField]
    private GameObject MedLog;

    /// <summary>
    /// Private reference to the tracker checking if the glass animation has played
    /// </summary>
    private bool hasPlayed = false;

    // Update is called once per frame
    void Update()
    {
        if (!glassBoxAnimation.isPlaying && !room4Key.GetComponent<PickUpObject>().enabled && hasPlayed)
        {
            ActivateKey();
        } 
        else if (glassBoxAnimation.isPlaying)
        {
            hasPlayed = true;
        }
    }

    void ActivateKey()
    {
        room4Key.GetComponent<PickUpObject>().enabled = true;
    }

    public void PlayGlassAnimation()
    {
        glassBoxAnimation.Play();
    }

    /// <summary>
    /// Checks that the switches are activated in the correct order, if they are not the switches are reset
    /// </summary>
    /// <param name="switchNum"></param>
    public void ActivateSwtich(int switchNum)
    {
        //0 represents switch 1 being activated
        //1 represents switch 2 being activated
        //2 represents switch 3 being activated
        switch (switchNum)
        {
            case 0:
                switch1Active = true;
                switch1.GetComponent<Switch>().isOn = true;
                break;
            case 1:
                if (switch1Active)
                {
                    switch2Active = true;
                    switch2.GetComponent<Switch>().isOn = true;
                }
                else
                {
                    ResetSwitches();
                }
                break;
                
            case 2:
                if (switch2Active)
                {
                    switch3.GetComponent<Switch>().isOn = true;
                    PlayGlassAnimation();
                    MedLog.SetActive(true);
                }
                else
                {
                    ResetSwitches();
                }
                break;
            default:
                ResetSwitches();
                break;
        }
    }

    /// <summary>
    /// Resets the switches by turning them off
    /// </summary>
    void ResetSwitches()
    {
        switch2.GetComponent<Switch>().TurnOff();
        switch3.GetComponent<Switch>().TurnOff();
        switch1Active = false;
        switch2Active = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the player enters the trigger collider for the room the present and future versions are assigned
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<TimeTravel>().present = roomPresent;
            other.GetComponent<TimeTravel>().future = roomFuture;
        }
    }
}
