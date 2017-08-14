using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalManager : MonoBehaviour {

    public GameObject manager; //this is where convomanger is held.  when click on journal it'll check against the havingConvo bool and if the friends are having a convo it won't open the journal
    private GameObject cameraMain; //this is the camera that the followmouse script is held on.  I'll need to access it

    public GameObject[] journalTextObject;

    //analytic for times the journal was opened
    public int journalOpened = 0;

    public int currentJournalPage = 0;

	// Use this for initialization
	void Start ()
    {
        cameraMain = GameObject.FindGameObjectWithTag("MainCamera");
	}

    void OnMouseDown()
    {
        if (manager.GetComponent<ConversationManager>().havingConvo == false)
        {
            manager.GetComponent<ConversationManager>().havingConvo = true;
            cameraMain.GetComponent<MouseLook>().LookTarget(gameObject, 5f);
            //journalInputField.ActivateInputField();
            journalTextObject[currentJournalPage].SetActive(true);
            journalOpened++;
        }
    }

    public void OnButtonSwitchPage(int pageUpOrDown)
    {
        if (currentJournalPage < journalTextObject.Length)
        {
            int previousJournalPage = currentJournalPage;
            currentJournalPage += pageUpOrDown;
            journalTextObject[currentJournalPage].SetActive(true);
            journalTextObject[previousJournalPage].SetActive(false);
        }
    }

    public void OnButtonExitJournal()
    {
        //escape the writing mode when button is pressed
        journalTextObject[currentJournalPage].SetActive(false);
        manager.GetComponent<ConversationManager>().havingConvo = false;
        cameraMain.GetComponent<MouseLook>().FreeView();
    }

}
