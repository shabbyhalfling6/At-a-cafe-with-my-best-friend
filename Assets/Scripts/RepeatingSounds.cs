using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingSounds : MonoBehaviour {

    public AudioClip[] repeatingNoises;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        int i = Random.Range(0, repeatingNoises.Length);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = repeatingNoises[i];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            int i = Random.Range(0, repeatingNoises.Length);
            audioSource.clip = repeatingNoises[i];
            audioSource.Play();
        }
    }
}
