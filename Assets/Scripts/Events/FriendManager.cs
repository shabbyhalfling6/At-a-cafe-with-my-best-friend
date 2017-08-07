using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendManager : MonoBehaviour
{
    public int friendEngagments;

    //friend could be looking ahead, biting pen, writing in journal, sipping coffee

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        friendEngagments++;
    }
}
