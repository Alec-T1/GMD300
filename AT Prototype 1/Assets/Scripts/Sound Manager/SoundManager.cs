using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioData;
    public AudioClip GemCollected;


    // Start is called before the first frame update
    void Awake()
    {
        audioData = GetComponent<AudioSource>();
    }


    public void GemCollect()
    {
        //Play Gem Collected Sound upon Gem being collected
        audioData.PlayOneShot(GemCollected, 1);
    }
}
