using UnityEngine;
using UnityEngine.Events;

public class TimeTravel : MonoBehaviour
{
    /// <summary>
    /// Public reference to the present game state object
    /// </summary>
    public GameObject present;

    /// <summary>
    /// Public reference to the future game state object
    /// </summary>
    public GameObject future;

    /// <summary>
    /// Public reference used ny the TravelPad Gameobjects to control when the player can use time travel
    /// </summary>
    public bool canTravel = false;

    /// <summary>
    /// 
    /// </summary>
    public bool travelAmountActive = false;

    /// <summary>
    /// 
    /// </summary>
    public int travelAmount = 0;

    /// <summary>
    /// The event that is triggered when the user changes the time game state to the future
    /// </summary>
    public UnityEvent futureTravel;

    /// <summary>
    /// The event that is triggered when the user changes the time game state to the past
    /// </summary>
    public UnityEvent pastTravel;

    /// <summary>
    /// The event that is triggered when the user changes the time game state to the past
    /// </summary>
    public UnityEvent changeTime;


    private void Start()
    {
        changeTime = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {
        if (canTravel)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // Changes the time to the future
                if (present.activeInHierarchy)
                {
                    future.SetActive(true);
                    futureTravel.Invoke();
                    present.SetActive(false);
                    
                }
                // Changes the time to the past
                else
                {
                    present.SetActive(true);
                    pastTravel.Invoke();
                    future.SetActive(false);
                }
                changeTime.Invoke();
                
            }
        }
    }
}
