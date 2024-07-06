using UnityEngine;

public class VoiceLineChanger : MonoBehaviour
{
    /// <summary>
    /// Private reference to the audio clip that the source will change to
    /// </summary>
    [SerializeField]
    private AudioClip clip;

    /// <summary>
    /// Private reference to the voice line audio source
    /// </summary>
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        //Finds the voice line audio source
        source = GameObject.FindGameObjectWithTag("VoiceLineSettings").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the player enters the trigger collider the playing clip changes to the new clip
        if (other.gameObject.tag == "Player")
        {
            source.clip = clip;
            source.Play();
        }
    }
}
