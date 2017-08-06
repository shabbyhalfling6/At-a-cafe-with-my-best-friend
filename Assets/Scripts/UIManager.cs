using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public bool invertY = false;
    public static UIManager _instance;

    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this.gameObject);
    }

    public static UIManager Instance
    {
        get
        {
            return _instance;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void InvertY ()
    {
        if (invertY)
            invertY = false;
        else
            invertY = true;
    }
}
