using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class ClickableObject : MonoBehaviour {

    private ConversationManager manager; //the object the conversationmanager script is attached to
    public Flowchart appropriateFlowchart;

    private Image cursor;
    public string blockName;

    public int clicksBeforeExecute = 1;
    public int clicksBeforeExecuteIn;

    //if the object is a coffee cup check this in the inspector
    public bool playerDrink = false;
    public bool isCoffee = true;
    public bool isPomo = false;

    //coffee cup sprites (probably should do this somewhere else)
    public Sprite[] coffeeCupSprites;
    public Sprite[] teaCupSprites;

    public SpriteRenderer spriteRenderer;

    public AudioClip[] ifAudio;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<ConversationManager>();
        cursor = GameObject.FindGameObjectWithTag("Cursor").GetComponent<Image>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //initalise clicks initial value
        clicksBeforeExecuteIn = clicksBeforeExecute;
    }

    void OnMouseDown()
    {
        if(clicksBeforeExecute > 0)
        {
            //decrement clicks
            clicksBeforeExecute--;
        }

        //if not having a convo, there is a block in fungus to run and you have clicked it enough
        if (manager.havingConvo == false && manager != null && clicksBeforeExecute == 0 && manager.pomoRunning == false)
        {
            //run block in fungus
            appropriateFlowchart.ExecuteBlock(blockName);
            if(ifAudio != null)
            {
                int i = Random.Range(0, ifAudio.Length);
                AudioSource audioSource = GetComponent<AudioSource>();

                if (ifAudio.Length > 0)
                {
                    audioSource.clip = ifAudio[i];
                    audioSource.Play();
                }
            }
        }

        if(manager.pomoRunning && isPomo)
        {
            appropriateFlowchart.ExecuteBlock(blockName);
        }

        //(poop)
        if (playerDrink)
        {
            if (isCoffee)
            {
                spriteRenderer.sprite = coffeeCupSprites[clicksBeforeExecute];
            }
            else
            {
                spriteRenderer.sprite = teaCupSprites[clicksBeforeExecute];
            }
        }
    }


    //cursor colour change
    void OnMouseOver()
    {
        cursor.color = Color.green;
    }

    void OnMouseExit()
    {
        cursor.color = Color.red;
    }
}
