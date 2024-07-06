using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    /// <summary>
    /// Private reference to the music player for the past enviroments
    /// </summary>
    [SerializeField]
    private AudioSource pastMusic;

    /// <summary>
    /// Private reference to the music player for the future enviroments
    /// </summary>
    [SerializeField]
    private AudioSource futureMusic;

    /// <summary>
    /// Private reference to the bool which allows music changes
    /// </summary>
    private bool changeMusic = false;

    /// <summary>
    /// The audio source which will be activated
    /// </summary>
    private AudioSource targetSource;

    /// <summary>
    /// The volume of the audio source
    /// </summary>
    private float volume;
    // Start is called before the first frame update
    void Start()
    {
        //Sets the initial volume of the audio sources
        volume = pastMusic.volume;
    }

    // Update is called once per frame
    void Update()
    {
        //If music is changing the current audio source gets disabled and the target gets enabled
        if (changeMusic)
        {
            //If the past source is the target the future source will slowly fade out
            if (pastMusic == targetSource)
            {
                //Fades out the future audio source
                futureMusic.volume = futureMusic.volume - 1 * Time.deltaTime;
                if (futureMusic.volume < 0.1)
                {
                    //Pauses the future audio source 
                    futureMusic.Pause();
                    changeMusic = false;
                    //Playes the past audio source
                    pastMusic.Play();
                }
            }
            else
            {
                //Fades out the past audio source
                pastMusic.volume = pastMusic.volume - 1 * Time.deltaTime;
                if (pastMusic.volume < 0.1)
                {
                    //Pauses the past audio source
                    pastMusic.Pause();
                    changeMusic = false;
                    //Plays the future audio source
                    futureMusic.Play();
                }
            }

        }
    }

    /// <summary>
    /// The method that switches the audio sources
    /// </summary>
    /// <param name="target"></param>
    public void ChangeMusic(int target)
    {
        //Target is an intager where 0 is the past audio source and 1 is the future audio source
        switch (target)
        {
            case 0:
                //Sets the target to the past audio source
                targetSource = pastMusic;
                changeMusic = true;
                break;
            case 1:
                //Sets the target to the future audio source
                targetSource = futureMusic; 
                changeMusic = true;
                break;
        }
    }
}
