using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class PomoRunner : MonoBehaviour {

    float counter; //counts up when timerRunning 
    bool timerRunning = false; //set to true when starts
    float timeToCheck; //adjusted when call RunTimer

    public Flowchart relevantFlowchart;

    private ConversationManager manager; //the object the conversationmanager script is attached to

    //public float minutesLeft;
    string calcdTimeLeft = "this is it"; //the string that goes into fungus

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<ConversationManager>();
    }

        // Update is called once per frame
    void Update () {
        if (timerRunning)
        {
            counter += Time.deltaTime; //counting up
            if(timeToCheck <= counter)
            {
                relevantFlowchart.ExecuteBlock("Time's Up"); //execute time's up
                timerRunning = false;
                counter = 0;
            }
        }
    }

    public void RunTimer(float timer)
    {
        timerRunning = true;
        timeToCheck = timer;
    }

    public void CancelTimer()
    {
        timerRunning = false;
        counter = 0f;
    }

    public void CalculateTimeLeft()
    {
        float timeLeft = (timeToCheck - counter) / 60;
        int intTimeLeft = ((int)timeLeft) + 1;
        calcdTimeLeft = intTimeLeft.ToString();

        relevantFlowchart.SetStringVariable("minutesLeft", calcdTimeLeft);
    }
}
