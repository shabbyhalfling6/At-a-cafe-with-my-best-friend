using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Clickables : MonoBehaviour {

    private GameObject manager; //the object the conversationmanager script is attached to
    public Flowchart appropriateFlowchart; //
    public string blockName;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
    }

    void OnMouseDown()
    {
        if (manager.GetComponent<ConversationManager>().havingConvo == false)
        {
            appropriateFlowchart.ExecuteBlock(blockName);
        }
    }
}
