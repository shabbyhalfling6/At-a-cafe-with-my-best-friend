using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ExitManager : MonoBehaviour {

    public GameObject manager; //the object the conversationmanager script is attached to
    public Flowchart conversationFlowchart;


    void OnMouseDown()
    {
        if (manager.GetComponent<ConversationManager>().havingConvo == false)
        {
            conversationFlowchart.ExecuteBlock("Exit?");
        }
    }
}
