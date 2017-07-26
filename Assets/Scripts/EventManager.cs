using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class EventManager : MonoBehaviour {

    bool eventHappening = false; //bool to show if event is/isn't happening
    float eventCeasedTime; //the time the most recent event finished
    float nextEventTime;

    //fungus
    public Flowchart eventFlowchart;
    List<string> eventBlockNames;

	// Use this for initialization
	void Start () {
        eventCeasedTime = Time.time;
        nextEventTime = eventCeasedTime + Random.Range(15, 60);

        //fungus
        eventBlockNames.Add("SipCoffee");
	}
	
	// Update is called once per frame
	void Update () {
		if(nextEventTime <= Time.time)
        {
            CallNewEvent();
        }
	}

    void CallNewEvent()
    {
        eventHappening = true;
        int index = Random.Range(0, eventBlockNames.Count);
        eventFlowchart.ExecuteBlock(eventBlockNames[index]);
        eventBlockNames.RemoveAt(index);
    }

    public void EndEventBlock()
    {
        eventCeasedTime = Time.time;
        nextEventTime = eventCeasedTime + Random.Range(5, 6);
        eventHappening = false;
    }
}
