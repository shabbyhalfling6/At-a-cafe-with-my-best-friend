using System.Collections;
using System.Collections.Generic;
using UnityEngine.Analytics;
using UnityEngine;
using Fungus;

public class AnalyticsTracker : MonoBehaviour
{
    public FriendManager friendclicks;
    public JournalManager journalClicks;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnApplicationQuit()
    {
        Analytics.CustomEvent("gameOver", new Dictionary<string, object>
        {

            { "FriendCliked",  friendclicks.friendEngagments },
            { "journalUsed",  journalClicks.journalOpened },
            { "timePlayed",  Time.realtimeSinceStartup }
        });
               
    }
}
