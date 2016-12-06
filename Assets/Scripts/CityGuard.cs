using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets;
using Assets.Scripts;
using UnityEngine.SceneManagement;

        //Script for City Guards only. Makes player warp back from the gate and tell the player to get lost.
public class CityGuard : MonoBehaviour {
    private Text dialog;
    private bool spotted;
    private Vector3 entrance = new Vector3(-91.719f, 3.223f, 0f);   //warp-back location
    private GameObject player;

    void Start() {

        player = GameObject.Find("Player");
        dialog = GameObject.Find("ShowDialog/DialogBox").GetComponent<Text>();
    }
    //player touches the trigger and get thrown back. Guards say mean things.
    void OnTriggerEnter2D(Collider2D coll) { 
        if (coll.CompareTag("Playa")) {
            dialog.text = DialogScript.getDialog(11);
            spotted = true;
        }
    }
    //gotta b in the update so player teleports back sooner.
    void Update() {  
        if (spotted == true) {
            player.transform.position = entrance;
            spotted = false;
        }
    }
}
    
 