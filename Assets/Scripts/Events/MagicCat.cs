using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCat : MonoBehaviour {

    public float counter;
    public float catAppears;
    public float catDisappears;
    public float chilling;

    bool catHere = false;
    public bool catVisible = false;

    float firstMin = 2f;
    float secondMin = 9f;
    float firstMax = 9f;
    float secondMax = 30f;

    public Sprite catSprite;

	// Use this for initialization
	void Start () {
        catAppears = Random.Range(firstMin, firstMax);
	}
	
	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime;
        chilling += Time.deltaTime;

        if (counter >= catAppears && !catHere)
        {
            if (!catVisible)
            {
                this.GetComponent<SpriteRenderer>().sprite = catSprite;
                catDisappears = Random.Range(secondMin, secondMax);
                catHere = true;
                chilling = 0f;
            }
            else
                counter = 0f;
        }
        
        if(chilling >= catDisappears && catHere)
        {
            if (!catVisible)
            {
                this.GetComponent<SpriteRenderer>().sprite = null;
                catAppears = Random.Range(secondMin, secondMax);
                catHere = false;
                counter = 0f;
            }
            else
                chilling = 0f;
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
