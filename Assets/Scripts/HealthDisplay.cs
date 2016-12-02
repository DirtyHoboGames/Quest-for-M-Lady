using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Displays the players health on the top-right corner of the screen. Gets the health from the StatKeeper class using getHealthAmount() method. Updates every frame.
using System;


namespace Assets.Scripts {
public class HealthDisplay : MonoBehaviour {


		private Text health;


	// Use this for initialization
	void Start () {

			health = GameObject.Find ("Health/HealthAmount").GetComponent<Text> ();
	
	}
	
	// Update is called once per frame
	void Update () {

			health.text = StatKeeper.getHealthAmount ();
	
		}
	}
}