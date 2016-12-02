using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class CityGuard : MonoBehaviour {
    private Text dialog;
    private bool spotted;
    private Vector3 entrance = new Vector3(-91.717f, 3.131f, 0f);
    private GameObject player;

    void Start() {

        player = GameObject.Find("Player");
        DialogScript.DialogInit();
        dialog = GameObject.Find("ShowDialog/DialogBox").GetComponent<Text>();
    }

    void OnTriggerEnter2D(Collider2D coll) { 
        if (coll.CompareTag("Playa")) {
            dialog.text = DialogScript.getDialog(11);
            spotted = true;
        }
    }

    void Update() {  
        if (spotted == true) {
            player.transform.position = entrance;
            spotted = false;
        }
    }
}
    
 