﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ConversationManager : MonoBehaviour {

    //shared
    float convoCeasedTime; //the time the most recent conversation stops
    public bool havingConvo = false; //whether or not a conversation is happening
    float conversationChance = 9f; //chance of starting a conversation compared to complimenting them out of ten
    float rollTalking; //a random number that is 'rolled' to determine a conversation chance
    float minNextTime = 15f; // min time until the next random conversation is triggered
    float maxNextTime = 45f; //max time til the next conversation is triggered

    //for friend talking to you
    float nextConvoStart; //the time when friend initiates next conversation

    //for you talking to friend
    bool friendEligible = true; //if friend is doing a thing she won't be eligible to talk to

    //fungus
    public Flowchart conversationFlowchart; //the flowchart for conversations
    public List<string> conversationBlockNames; //put down the individual block names for convos

    //for the pomo feature
    public bool pomoRunning = false;

    // Use this for initialization
    void Start () {
        //for friend
        convoCeasedTime = Time.time; //start the ceased time as time game starts
        nextConvoStart = convoCeasedTime + Random.Range(minNextTime, maxNextTime); //set the time the friend starts talking to you - should be 15-60
        
        //fungus conversations
        conversationBlockNames.Add("Tinder");
        conversationBlockNames.Add("Dreams");
        conversationBlockNames.Add("Mean Girls");
        conversationBlockNames.Add("Pain");
        conversationBlockNames.Add("Knifey");
        conversationBlockNames.Add("Music");
        conversationBlockNames.Add("Baby Cheeks");
        conversationBlockNames.Add("Tiniest Bluetooth");
        conversationBlockNames.Add("Linda Evangelista");
        conversationBlockNames.Add("Beautiful");
        conversationBlockNames.Add("I love you");
        conversationBlockNames.Add("You look great");
        conversationBlockNames.Add("Better Person");
        conversationBlockNames.Add("Waxed");
        conversationBlockNames.Add("Bus seats");
        conversationBlockNames.Add("Food Mishaps");
        conversationBlockNames.Add("Catcalling");
        conversationBlockNames.Add("Bad pickup lines");
        conversationBlockNames.Add("Impact");
        conversationBlockNames.Add("Guy Coworker");
        conversationBlockNames.Add("Gross Food");
        conversationBlockNames.Add("Shame");
        conversationBlockNames.Add("Magpie");
        conversationBlockNames.Add("Unwanted Text");
    }
	
	// Update is called once per frame
	void Update () {
		if(nextConvoStart <= Time.time && !havingConvo && friendEligible && !pomoRunning)
        {
            havingConvo = true;
            CallConvoBlock();
        }
	}

    void CallConvoBlock()
    {
        friendEligible = false;
        int index = Random.Range(0, conversationBlockNames.Count);
        conversationFlowchart.ExecuteBlock(conversationBlockNames[index]);
        conversationBlockNames.RemoveAt(index);
    }

    public void EndConvoBlock()
    {
        convoCeasedTime = Time.time;
        nextConvoStart = convoCeasedTime + Random.Range(minNextTime, maxNextTime);
        havingConvo = false;
    }

    public void FriendEligibleTrue()
    {
        //WaitForSeconds(5);
        friendEligible = true;
    }

    public void HavingConvoTrue() //to call inside fungus
    {
        havingConvo = true;
    }

    public void ClickOnFriend()
    {
        if (friendEligible == true && havingConvo == false)
        {
            CallConvoBlock();
            havingConvo = true;
        }
    }

    public void SetPomoRunTrue()
    {
        pomoRunning = true;
    }

    public void SetPomoRunFalse()
    {
        pomoRunning = false;
    }

    public void AddBlock(string newBlock)
    {
        conversationBlockNames.Add(newBlock);
    }
}
