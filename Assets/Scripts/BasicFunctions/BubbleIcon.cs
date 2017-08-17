using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleIcon : MonoBehaviour {

    public ConversationManager manager;

	// Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<ConversationManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(manager.havingConvo == true && manager.pomoRunning == false)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
	}
}
