using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InGameMenu : MonoBehaviour
{
    /// <summary>
    /// Private reference to the in game menu canvas
    /// </summary>
    [SerializeField]
    private Canvas mainCanvas;

    // Update is called once per frame
    void Update()
    {
        //Allows the menu to become visible and player movement to stop when the menu is opened
        if (mainCanvas.enabled == false && Input.GetKeyDown(KeyCode.Tab))
        {
            //Disables player movement
            GetComponent<FirstPersonController>().enabled = false;
            //Disables the player collider
            GetComponent<CharacterController>().enabled = false;
            //Enables the main menu
            mainCanvas.enabled = true;

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    /// <summary>
    /// Resets the cursor to not visible and locked to the centre of the screen
    /// </summary>
    public void ResetCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
