using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CoffeeCupInteraction : MonoBehaviour {

    public int clicksBeforeEmpty = 5;

    public Flowchart eventFlowchart;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        clicksBeforeEmpty--;

        if(clicksBeforeEmpty >= 0)
        {
            eventFlowchart.ExecuteBlock("PlayerServed");
        }
    }

}
