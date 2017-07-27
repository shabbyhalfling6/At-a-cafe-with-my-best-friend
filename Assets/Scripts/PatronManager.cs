using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronManager : MonoBehaviour {

    //patron sits in seat
    //occasionally sips coffee

    bool sippingCoffee = false;
    float timeSinceSip; //the time the most recent sip
    float timeToSip;

    // Use this for initialization
    void Start () {
        timeSinceSip = Time.time;
        timeToSip = timeSinceSip + Random.Range(30, 120);
	}
	
	// Update is called once per frame
	void Update () {
		if(timeToSip <= Time.time && !sippingCoffee)
        {
            sippingCoffee = true;
            SipCoffee();
        }
	}

    void SipCoffee()
    {
        //trigger sip animation
        sippingCoffee = false;
    }
}
