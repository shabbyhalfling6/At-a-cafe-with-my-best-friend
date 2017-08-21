using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishwasherCycle : MonoBehaviour {

    public AudioClip[] dishNoises;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        int i = Random.Range(0, dishNoises.Length);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = dishNoises[i];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            int i = Random.Range(0, dishNoises.Length);
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.clip = dishNoises[i];
            audioSource.Play();
        }
    }
}
