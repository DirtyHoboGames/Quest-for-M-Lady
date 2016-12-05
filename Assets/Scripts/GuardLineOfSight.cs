using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class GuardLineOfSight : MonoBehaviour { //Script for guards to detect player, hit the player and teleport the player to the beginning 
                                                //of the level.
    private Text dialog;                       
	private bool spotted;
	private Vector3 entrance = new Vector3(-16.10f, -5.782f, -0.355f);
	private GameObject player;

    void Start() {

		player = GameObject.Find ("Player");
        dialog = GameObject.Find("ShowDialog/DialogBox").GetComponent<Text>();
    }

    void OnTriggerEnter2D(Collider2D coll) { //guard collider checks for player and deals damage, says some stuff, invokes checkstatus method.
        if (coll.CompareTag("Playa")) {
            //StatKeeper.receiveDamage(4);
            dialog.text = DialogScript.getDialog(14);
            spotted = true;
        }
    }

    void Update() {          //looks if guards spotted player every frame and teleports them in to the beginning of the level.
        if (spotted == true) {
			CheckStatus();
            player.transform.position = entrance;
            spotted = false;
        }
    }

    void CheckStatus() {    //method for damaging player and teleport.
        if (StatKeeper.getHealth() >=5) {
            StatKeeper.receiveDamage (4);


        }
    }
}