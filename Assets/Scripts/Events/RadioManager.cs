using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class RadioManager : MonoBehaviour {

    public AudioSource[] radioChannels;
    public AudioSource currentChannel;

	// Use this for initialization
	void Start () {
        radioChannels = gameObject.GetComponents<AudioSource>();
	}

    private void OnMouseDown()
    {
        Debug.Log("Mouse click registered");
        int i = Random.Range(0, radioChannels.Length);
        while (radioChannels[i] == currentChannel)
        {
            i = Random.Range(0, radioChannels.Length);
        }
        currentChannel.Stop();
        //radioChannels[i].
        currentChannel = radioChannels[i];
        //currentChannel.
        currentChannel.Play();
        //currentChannel.loop = true;
    }
}
