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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GemCollect()
    {
        audioData.PlayOneShot(GemCollected, 1);
    }
}
