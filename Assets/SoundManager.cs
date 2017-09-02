using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager This;

	//All sounds will be handled in here
	AudioSource[] audioSource;//different sound channels
	public AudioClip rocket;
	public AudioClip win;
	public AudioClip lose;
	public AudioClip button1;
	public AudioClip button2;
	public AudioClip fuelPickup;
	public AudioClip music;

	// Use this for initialization
	void Start () {
		audioSource = GetComponents<AudioSource> ();
		if (This == null) {
			This = this;
		}

		Music ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ThrustSound(bool play) {
		if (!audioSource[0].isPlaying && play) {
			audioSource[0].PlayOneShot (rocket);
		} else if (!play) {
			audioSource[0].Stop ();
		}
	}

	public void WinSound() {
		audioSource[0].PlayOneShot (win);
	}

	public void LoseSound() {
		audioSource[0].PlayOneShot (lose);
	}

	public void ButtonSound1() {
		audioSource[1].PlayOneShot (button1);
	}

	public void ButtonSound2() {
		audioSource[1].PlayOneShot (button2);
	}

	public void FuelSound() {
		audioSource[1].PlayOneShot (fuelPickup);
	}

	public void Music() {
		audioSource[0].PlayOneShot (music);
	}
}
