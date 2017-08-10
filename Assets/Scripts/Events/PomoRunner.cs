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

    //public float minutesLeft;
    public string calcdTimeLeft = "this is it";

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
                relevantFlowchart.ExecuteBlock("Time's Up");
                timerRunning = false;
                counter = 0;
            }
        }
	}

    public void RunTimer(float timer)
    {
        //counter += Time.deltaTime;
        timerRunning = true;
        timeToCheck = timer;
    }

    public void CancelTimer()
    {
        timerRunning = false;
        counter = 0f;
    }

    public void CalculateTimeLeft(float total)
    {
        float timeLeft = total - (counter / 60);
        int intTimeLeft = (int)timeLeft;
        calcdTimeLeft = intTimeLeft.ToString();

        relevantFlowchart.SetStringVariable("minutesLeft", calcdTimeLeft);
    }
}
