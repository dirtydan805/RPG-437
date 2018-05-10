using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour {

	public AudioClip currentMessage;
	public float Volume;
	AudioSource audio;
	public bool alreadyPlayed = false;

	void Start(){
		audio = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(){
		if (!alreadyPlayed) {
			audio.PlayOneShot (currentMessage, Volume);
			alreadyPlayed = true;
		}
	}
}