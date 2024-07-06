using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    /// <summary>
    /// Private reference to the player gameobject
    /// </summary>
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //Finds the player gameobject in the scene
        player = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        //Sets the connected gameobject to look at the player
        transform.LookAt(player.transform.position);
    }
}
