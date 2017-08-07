using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackboardManager : MonoBehaviour {

    private string[] puns = { "Our thickshakes are dairy good <3", "Maybe she's born with it, maybe it's caffeine", "It's a brew-tiful day!", "Iced coffee?? Cool beans!" };
    private string currentPun;
    public Text textbox;

	// Use this for initialization
	void Start () {
        currentPun = puns[0];
	}

    public void NewBlackboard()
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
