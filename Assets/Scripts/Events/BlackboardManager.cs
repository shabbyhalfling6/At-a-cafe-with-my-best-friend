using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackboardManager : MonoBehaviour {

    private string[] puns = {
        "Our thickshakes are dairy good <3",
        "Maybe she's born with it, maybe it's caffeine",
        "It's a brew-tiful day!",
        "Iced coffee?? Cool beans!",
        "Livin' la vida mocha",
        "I like big cups and I cannot lie",
        "Have a cup of positivi-tea!",
        "Pour choices flow from a lack of coffee"
    };
    private string currentPun;
    public Text textbox;

	// Use this for initialization
	void Start () {
        int i = Random.Range(0, puns.Length);
        textbox.text = puns[i];
        currentPun = puns[i];
    }
    
    private void OnMouseDown()
    {
        int i = Random.Range(0, puns.Length);
        while (puns[i] == currentPun)
        {
            i = Random.Range(0, puns.Length);
        }
        textbox.text = puns[i];
        currentPun = puns[i];
    }
}
