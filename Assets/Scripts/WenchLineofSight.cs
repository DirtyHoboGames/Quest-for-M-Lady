﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets;
using Assets.Scripts;
using UnityEngine.SceneManagement;
    
    //Script for wench. If wench sees the player it asks for rose. If not given, player takes damage and teleports back to the stairs.
public class WenchLineofSight : MonoBehaviour {
    private Text dialog;
    private GameObject WenchStoryWindow;
    private Button YesButton;
    private Button NoButton;
	private bool wenchFlipped = true;
	private bool coRoutineStarted = true;
    private bool roseGiven = false;
	private Collider2D boxCollider;

	//This is the players position when the scene first loads
	private Vector2 entrance = new Vector2(-36.205f, -8.083f);

	//This represents the player
	private GameObject player;
    

    //Finds all buttons and objects.
    void Start() {
		
        WenchStoryWindow = GameObject.Find("WenchStoryWindow");
        YesButton = GameObject.Find("WenchStoryWindow/YesButton").GetComponent<Button>();
        NoButton = GameObject.Find("WenchStoryWindow/NoButton").GetComponent<Button>();
        YesButton.onClick.AddListener(() => YesButtonClicked());
        NoButton.onClick.AddListener(() => NoButtonClicked());
        WenchStoryWindow.SetActive(false);

		dialog = GameObject.Find ("ShowDialog/DialogBox").GetComponent<Text> ();

		boxCollider = GameObject.Find ("Wench").GetComponent<BoxCollider2D> ();

		//Finds the player object
		player = GameObject.Find ("Player");

    }
        /// <summary>
        /// Wench can turn. 
        /// </summary>
    void Update() {
        if(coRoutineStarted) {
            coRoutineStarted = false;
			StartCoroutine (flipWench ());
        }
	}
        /// <summary>
        /// If rose is given, it will be removed from inventory and wench will no longer attack the player if seen.
        /// </summary>
    void YesButtonClicked() {
        hideStory();
        InventoryHandler.GiveRose();
        roseGiven = true;

		boxCollider.enabled = false;

		dialog.text = DialogScript.getDialog(6);


    }

    /// <summary>
    /// changes the direction the wench looks at. 
    /// </summary>
    /// <returns></returns>
    IEnumerator flipWench() {

		wenchFlip (1);
        yield return new WaitForSeconds (3);
        wenchFlip (-1);
        yield return new WaitForSeconds (3);
        coRoutineStarted = true;
    }

    /// <summary>
    /// Damages player, teleports player.
    /// </summary>
    void NoButtonClicked() {
        hideStory();
        StatKeeper.receiveDamage(6);
        
		player.transform.position = entrance;

    }

    void showStory() {
        WenchStoryWindow.SetActive(true);
    }

    void hideStory() {
        WenchStoryWindow.SetActive(false);
    }

	/// <summary>
	/// Raises the trigger enter 2d when the player hits the trigger and activates the story window.
	/// </summary>
	/// <param name="coll">Coll.</param>
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Playa") && roseGiven == false) { //if player hits the collider, time freezes and dialogue follows.
            
            showStory();
            Debug.Log("lel");
        }
    }
    //flips the wench and the collider
	private void wenchFlip(int direction) {
		if (direction > 0 && !wenchFlipped || direction < 0 && wenchFlipped) {
			wenchFlipped = !wenchFlipped;
			transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
		}
	}
}
