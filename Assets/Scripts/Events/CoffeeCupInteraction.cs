using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CoffeeCupInteraction : MonoBehaviour {

    public int clicksBeforeEmpty = 4;
    public int clicksBeforeEmptyIn = 4;

    public Flowchart eventFlowchart;

    public Sprite[] coffeeCupSprites;
    public Sprite[] teaCupSprites;

    void OnMouseDown()
    {
        //take a sip from the drink
        clicksBeforeEmpty--;

        //if the cup is empty
        if(clicksBeforeEmpty == 0)
        {
            //execute the player served event in fungus so the barista will serve the player
            eventFlowchart.ExecuteBlock("PlayerServed");
            this.GetComponent<SpriteRenderer>().sprite = coffeeCupSprites[0];
        }
        else
        {
            //change the sprite to the current level of sip (only coffee atm)
            this.GetComponent<SpriteRenderer>().sprite = coffeeCupSprites[clicksBeforeEmpty];
        }
    }

}
