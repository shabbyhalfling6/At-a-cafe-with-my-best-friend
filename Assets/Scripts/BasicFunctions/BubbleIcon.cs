using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleIcon : MonoBehaviour {

    ConversationManager manager;
    Image iconSprite;

	// Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<ConversationManager>();
        iconSprite = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if(manager.havingConvo == true && manager.pomoRunning == false)
        {
            gameObject.GetComponent<Image>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Image>().enabled = false;
        }
	}
}
