using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class ClickableObject : MonoBehaviour {

    private ConversationManager manager; //the object the conversationmanager script is attached to
    public Flowchart appropriateFlowchart; //

    public Image cursor;
    public string blockName;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<ConversationManager>();
        cursor = GameObject.FindGameObjectWithTag("Cursor").GetComponent<Image>();
    }

    void OnMouseDown()
    {
        if (manager.havingConvo == false)
        {
            appropriateFlowchart.ExecuteBlock(blockName);
        }
    }

    void OnMouseOver()
    {
        cursor.color = Color.green;
    }
}
