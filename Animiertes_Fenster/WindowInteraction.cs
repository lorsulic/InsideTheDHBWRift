﻿using UnityEngine;
using System.Collections;

public class WindowInteraction : MonoBehaviour {


	public AudioClip windowOpen;
	public AudioClip windowClose;

	private GameObject player;
	private Properties playerProperties;


	void Awake() {
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag("Player");
		playerProperties = player.GetComponent<Properties> ();
	}
	


	void OnTriggerEnter(Collider other) {

		// if player enters collider of trash can, and has a object.
		if (other.gameObject == player && playerProperties.hasObject == false) {

			// set current action to 
			playerProperties.currentPossibleAction = Properties.currentPossibleActionEnum.InteractWithWindow.ToString ();
			playerProperties.currentWindow = gameObject;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject == player) {
			playerProperties.currentPossibleAction = "";
		}
	}

	public void InteractWithWindow() {

		if (playerProperties.currentWindow.GetComponent<Animator>().GetBool ("Open")) {
			
			Debug.Log("Trigger and close it");
			
			playerProperties.currentWindow.GetComponent<Animator>().SetBool ("Open", false);
			
			// play window sound for closing
			playerProperties.currentWindow.audio.clip = windowClose;
			playerProperties.currentWindow.audio.Play ();
			
			// add to score
			playerProperties.score += 10;
		} else {
			playerProperties.currentWindow.GetComponent<Animator>().SetBool ("Open", true);
			
			Debug.Log("Trigger and open it");
			
			// play window sound for opening
			playerProperties.currentWindow.audio.clip = windowOpen;
			playerProperties.currentWindow.audio.Play ();
			
			// add to score
			playerProperties.score -= 10;
		}
	}

}
