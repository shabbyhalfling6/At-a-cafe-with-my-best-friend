using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour {

    public AudioClip[] theAudio;

    public float minTime;
    public float maxTime;

    float timeSinceSound;
    float timeToSound;

    // Use this for initialization
    void Start () {
        timeSinceSound = Time.time;
        timeToSound = timeSinceSound + Random.Range(minTime, maxTime);
    }
	
	// Update is called once per frame
	void Update () {
        if (timeToSound <= Time.time)
        {
            PlaySound();
            timeSinceSound = Time.time;
            timeToSound = timeSinceSound + Random.Range(minTime, maxTime);
        }
    }

    void PlaySound()
    {
        int i = Random.Range(0, theAudio.Length);
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = theAudio[i];
        audioSource.Play();
    }
}
