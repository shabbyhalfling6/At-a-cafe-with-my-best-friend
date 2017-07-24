using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationManager : MonoBehaviour {

    //shared
    float convoCeasedTime;
    bool havingConvo = false;
    float conversationChance = 9f;
    float rollTalking;
    bool deepConvoAvail = false;
    float timeTilDeepAvail = 120f;

    //for friend talking to you
    float nextConvoStart;

    //for you talking to friend
    bool friendEligible = true;

	// Use this for initialization
	void Start () {
        //for friend
        convoCeasedTime = Time.time;
        nextConvoStart = convoCeasedTime + Random.Range(15, 60);

        //for you

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void RollChance()
    {
        rollTalking = Random.Range(1, 10);
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
