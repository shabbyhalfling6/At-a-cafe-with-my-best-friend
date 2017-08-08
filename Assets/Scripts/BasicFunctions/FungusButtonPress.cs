using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
using UnityEngine.EventSystems;

public class FungusButtonPress : MonoBehaviour {
    
    public KeyCode keycode;
    	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(keycode))
        {
            ExecuteEvents.Execute<IPointerClickHandler>(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
        }
	}
}
