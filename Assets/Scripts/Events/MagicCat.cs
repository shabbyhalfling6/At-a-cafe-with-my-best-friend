using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCat : MonoBehaviour {

    public GameObject cameraMain;

    public float counter;
    float catAppears;
    float catDisappears;
    public float chilling;

    bool catHere = false;

    float firstMin = 2f;
    float secondMin = 9f;
    float firstMax = 9f;
    float secondMax = 30f;

    float cameraMin = -235f;
    float cameraMax = -135f;

    bool cameraAllG = false;

    Vector3 hiddenCat = new Vector3(22.82f, 4.167f, 20.97f);
    Vector3 visibleCat = new Vector3(22.82f, 6.144f, 17.54f);

	// Use this for initialization
	void Start () {
        catAppears = Random.Range(firstMin, firstMax);
	}
	
	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime;
        chilling += Time.deltaTime;
        
        if (counter >= catAppears && cameraMain.transform.rotation.y >= cameraMin && cameraMain.transform.rotation.y <= cameraMax && catHere == false) //between -250 & -115
        {
            transform.position = visibleCat;
            catDisappears = Random.Range(secondMin, secondMax);
            chilling = 0f;
            catHere = true;
        }
        
        if(chilling >= catDisappears && cameraMain.transform.rotation.y >= cameraMin && cameraMain.transform.rotation.y <= cameraMax && catHere == true)
        {
            transform.position = hiddenCat;
            catAppears = Random.Range(secondMin, secondMax);
            counter = 0f;
            catHere = false;
        }
        /*
        if(cameraMain.transform.rotation.y >= cameraMin && cameraMain.transform.rotation.y <= cameraMax)
        {
            cameraAllG = true;
        }
        else
        {
            cameraAllG = false;
        }*/
	}
}
