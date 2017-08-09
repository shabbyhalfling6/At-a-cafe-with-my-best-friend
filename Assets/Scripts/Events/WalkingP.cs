using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingP : MonoBehaviour {

    Vector3 outsideCafe = new Vector3(0, 4, 25);
    Vector3 insideCafe = new Vector3(0, 4, 3);

    float counter = 0f;
    float comeIn = 180f;
    float waiting = 0f;
    float gotCoffee = 120f;

    float speed = 4f;

    bool atCounter = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if(counter >= comeIn)
        {
            //transform.position = Vector3.Lerp(outsideCafe, insideCafe, lerpTime);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, insideCafe, step);
        }

        if(gameObject.transform.position == insideCafe)
        {
            atCounter = true;
        }

        if(atCounter == true)
        {
            waiting += Time.deltaTime;
        }

        if(waiting >= gotCoffee)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, outsideCafe, step);
            counter = 0f;
        }

        if(gameObject.transform.position == outsideCafe)
        {
            waiting = 0f;
            counter += Time.deltaTime;
        }
    }

}
