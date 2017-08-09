using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Testing : MonoBehaviour {

    string newText = "The new text of the story is this.  Look at me setting new texts.";
    public Flowchart flow;
    public Command newCommand;
    public Say newSay;

	// Use this for initialization
	void Start () {
        //flow.FindBlock("Check Pomo").
        //newCommand.
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            
        }
	}
}
