using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationManager : MonoBehaviour {

    //shared
    float convoCeasedTime; //the time the most recent conversation stops
    bool havingConvo = false; //whether or not a conversation is happening
    float conversationChance = 9f; //chance of starting a conversation compared to complimenting them out of ten
    float rollTalking; //a random number that is 'rolled' to determine a conversation chance
    bool deepConvoAvail = false; //whether or not the player can discuss certain topics.  Unlocked after a period of time
    float timeTilDeepAvail = 120f; // the amount of time until deeper conversation topics are unlocked

    //for friend talking to you
    float nextConvoStart; //the time when friend initiates next conversation

    //for you talking to friend
    bool friendEligible = true; //if friend is doing a thing she won't be eligible to talk to

	// Use this for initialization
	void Start () {
        //for friend
        convoCeasedTime = Time.time; //start the ceased time as time game starts
        nextConvoStart = convoCeasedTime + Random.Range(15, 60); //set the time the friend starts talking to you

        //for you

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void RollChance()
    {
        rollTalking = Random.Range(1, 10);  //determine whether a conversation or compliment will be triggered
        if(rollTalking <= conversationChance)
        {
            CallConvoBlock();
        }
        else
        {
            CallCompliment();
        }
    }

    void CallConvoBlock()
    {
        havingConvo = true;
        friendEligible = false;
        //call the convo block in fungus
    }

    void EndConvoBlock()
    {
        havingConvo = false;
        convoCeasedTime = Time.time;
        nextConvoStart = convoCeasedTime + Random.Range(15, 60);
        //WaitForSeconds(5);
        friendEligible = true;
        //convo ends and switches havingConvo to false
    }

    void ClickOnFriend()
    {
        if (friendEligible)
        {
            RollChance();
        }
    }

    void CallCompliment()
    {
        //call a compliment block in unity
    }

    void DeepAvail()
    {
        if(timeTilDeepAvail >= Time.time)
        {
            //trigger certain topics becoming available
        }
    }
}
