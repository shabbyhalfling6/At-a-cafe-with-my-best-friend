using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCat : MonoBehaviour {

    public GameObject cameraMain;

    float counter;
    float catAppears;
    float catDisappears;
    float chilling;

    bool catHere = false;

    float firstMin = 2f;
    float secondMin = 9f;
    float firstMax = 9f;
    float secondMax = 30f;

    float cameraMin = -250f;
    float cameraMax = -115f;

    bool cameraAllG = false;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
        //gameObject.renderer
        catAppears = Random.Range(firstMin, firstMax);
	}
	
	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime;
        chilling += Time.deltaTime;
        
        if (counter >= catAppears && cameraAllG == true && catHere == false) //between -250 & -115
        {
            gameObject.SetActive(true);
            catDisappears = Random.Range(secondMin, secondMax);
            chilling = 0f;
            catHere = true;
        }
        
        if(chilling >= catDisappears && cameraAllG == true && catHere == true)
        {
            gameObject.SetActive(false);
            catAppears = Random.Range(secondMin, secondMax);
            counter = 0f;
            catHere = false;
        }

        if(cameraMain.transform.position.y > cameraMin && cameraMain.transform.position.y < cameraMax)
        {
            cameraAllG = true;
        }
        else
        {
            cameraAllG = false;
        }
	}
}
