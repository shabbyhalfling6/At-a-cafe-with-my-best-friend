using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefManager : MonoBehaviour {

    float minTime = 15;
    float maxTime = 30;

    float timeSinceCut; //the time the most recent sip
    float timeToCut;

    public Sprite cutting;
    Sprite notCutting;
    bool currentlyCutting = false;

    public AudioClip[] chopAudio;
    public AudioClip[] sharpenAudio;

    // Use this for initialization
    void Start()
    {
        //setting up cutting schedule
        timeSinceCut = Time.time;
        timeToCut = timeSinceCut + Random.Range(minTime, maxTime);

        //grabbing not cutting sprite
        notCutting = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToCut <= Time.time && !currentlyCutting)
        {
            currentlyCutting = true;
            StartCoroutine(SipCoffee());
        }
    }

    IEnumerator SipCoffee()
    {
        //trigger sip animation
        gameObject.GetComponent<SpriteRenderer>().sprite = cutting;
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<SpriteRenderer>().sprite = notCutting;
        int i = Random.Range(0, chopAudio.Length);
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = chopAudio[i];
        audioSource.Play();
        timeSinceCut = Time.time;
        timeToCut = timeSinceCut + Random.Range(minTime, maxTime);
        currentlyCutting = false;
    }
}
