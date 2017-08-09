using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PomoRunner : MonoBehaviour {

    float twentyfiveMins = 1500f;
    float thirteenMins = 780f;
    float sevenMins = 420f;
    float counter;
    bool timerRunning = false;
    float timeToCheck;

    public Flowchart relevantFlowchart;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (timerRunning)
        {
            counter += Time.deltaTime;
            if(timeToCheck <= counter)
            {
                //execute block times up
                timerRunning = false;
                counter = 0;
            }
        }
	}

    void RunTimer(float timer)
    {
        //counter += Time.deltaTime;
        timerRunning = true;
        timeToCheck = timer;
    }

    void CancelTimer()
    {
        timerRunning = false;
        counter = 0f;
    }
}
