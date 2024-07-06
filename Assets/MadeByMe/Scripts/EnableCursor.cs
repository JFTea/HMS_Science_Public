using UnityEngine;

public class EnableCursor : MonoBehaviour
{
    //Sets the cursor to visible and confined
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
