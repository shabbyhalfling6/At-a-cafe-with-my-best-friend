using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDriving : MonoBehaviour {

    Vector3 firstPoint = new Vector3(-24, 0, 2);
    Vector3 secondPoint = new Vector3(17, 0, 2);

    float counter = 0f;
    float comeIn = 180f;
    float waiting = 0f;
    float gotCoffee = 120f;

    float speed = 4f;

    bool passed = false;

    // Update is called once per frame
    void Update()
    {
        if (counter >= comeIn)
        {
            //transform.position = Vector3.Lerp(outsideCafe, insideCafe, lerpTime);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, secondPoint, step);
        }

        if (gameObject.transform.position == secondPoint)
        {
            passed = true;
        }

        if (passed == true)
        {
            waiting += Time.deltaTime;
        }

        if (waiting >= gotCoffee)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, firstPoint, step);
            counter = 0f;
        }

        if (gameObject.transform.position == firstPoint)
        {
            waiting = 0f;
            counter += Time.deltaTime;
        }
    }
}
