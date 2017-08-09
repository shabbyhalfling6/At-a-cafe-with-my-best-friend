using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCat : MonoBehaviour {

    public float counter;
    public float catAppears;
    public float catDisappears;
    public float chilling;

    bool catHere = false;
    bool catVisible = false;

    float firstMin = 2f;
    float secondMin = 9f;
    float firstMax = 9f;
    float secondMax = 30f;

    float cameraMin = -250f;
    float cameraMax = -115f;

    public Sprite catSprite;

    //Vector3 hiddenCat = new Vector3(22.82f, 4.167f, 20.97f);
   // Vector3 visibleCat = new Vector3(22.82f, 6.144f, 17.54f);

	// Use this for initialization
	void Start () {
        catAppears = Random.Range(firstMin, firstMax);
	}
	
	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime;
        chilling += Time.deltaTime;
        
        /*
        if (Camera.main.transform.rotation.y <= cameraMin) //&& Camera.main.transform.rotation.y == cameraMax) //between -250 & -115
        {
            Debug.Log("visibleCat");
        }

        if (Camera.main.transform.rotation.y >= cameraMin) //&& Camera.main.transform.rotation.y <= cameraMax && catHere == true)
        {
            Debug.Log("notVisibleCat");
        }
        */

        if (counter >= catAppears && !catHere)
        {
            if (!catVisible)
            {
                //transform.position = visibleCat;
                this.GetComponent<SpriteRenderer>().sprite = catSprite;
                catDisappears = Random.Range(secondMin, secondMax);
                catHere = true;
            }
            chilling = 0f;
        }
        
        if(chilling >= catDisappears && catHere)
        {
            if (!catVisible)
            {
                //transform.position = hiddenCat;
                this.GetComponent<SpriteRenderer>().sprite = null;
                catAppears = Random.Range(secondMin, secondMax);
                catHere = false;
            }
            counter = 0f;
        }
	}

    private void OnBecameVisible()
    {
        catVisible = true;
    }

    private void OnBecameInvisible()
    {
        catVisible = false;
    }
}
