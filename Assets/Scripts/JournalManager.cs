﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalManager : MonoBehaviour {

    public GameObject manager; //this is where convomanger is held.  when click on journal it'll check against the havingConvo bool and if the friends are having a convo it won't open the journal

    public GameObject journalTextObject;
    public InputField journalInputField;

    public int journalOpened;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*
        //raycast the mouse point to the game world to test if you are clicking something
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if()
                //activate journal object in scene
                journalTextObject.SetActive(true);
                Cursor.visible = true;
            }
        }*/

        //escape the writing mode when pressing escape
        if (Input.GetKey(KeyCode.Escape))
        {
            journalTextObject.SetActive(false);
        }

    }

    void OnMouseDown()
    {
        if (manager.GetComponent<ConversationManager>().havingConvo == false)
        {
            journalInputField.ActivateInputField();
            journalTextObject.SetActive(true);
            journalOpened++;
        }
    }

}
