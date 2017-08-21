using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronManager : MonoBehaviour {

    //patron sits in seat
    //occasionally sips coffee

    float minTime = 15;
    float maxTime = 30;

    float timeSinceSip; //the time the most recent sip
    float timeToSip;

    public Sprite sipping;
    Sprite notSipping;
    bool sippingCoffee = false;

    public AudioClip[] cupChinkAudio;

    // Use this for initialization
    void Start () {
        timeSinceSip = Time.time;
        timeToSip = timeSinceSip + Random.Range(minTime, maxTime);

        notSipping = gameObject.GetComponent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
		if(timeToSip <= Time.time && !sippingCoffee)
        {
            sippingCoffee = true;
            StartCoroutine(SipCoffee());
        }
	}

    IEnumerator SipCoffee()
    {
        //trigger sip animation
        gameObject.GetComponent<SpriteRenderer>().sprite = sipping;
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<SpriteRenderer>().sprite = notSipping;
        int i = Random.Range(0, cupChinkAudio.Length);
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = cupChinkAudio[i];
        audioSource.Play();
        timeSinceSip = Time.time;
        timeToSip = timeSinceSip + Random.Range(minTime, maxTime);
        sippingCoffee = false;
    }
}
