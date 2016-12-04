using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class WagonHide : MonoBehaviour {
    private Text Dialog;
    private GameObject wagonHideWindow;
    private GameObject wagonHideTrigger;
    private Button WagonYesButton;
    private Button WagonNoButton;


    // Use this for initialization
    void Start () {

        wagonHideWindow = GameObject.Find("WagonHideWindow");
        WagonYesButton = GameObject.Find("WagonHideWindow/WagonYesButton").GetComponent<Button>();
        WagonNoButton = GameObject.Find("WagonHideWindow/WagonNoButton").GetComponent<Button>();
        WagonYesButton.onClick.AddListener(() => WagonYesButtonClicked());
        WagonNoButton.onClick.AddListener(() => WagonNoButtonClicked());
        wagonHideWindow.SetActive(false);

    }

    void OnTriggerEnter2D(Collider2D colli) {

        if (colli.CompareTag("Playa")) {

            wagonHideWindow.SetActive(true);
        }
    }

    void WagonYesButtonClicked() {
        hideWagonStory();
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }

    void WagonNoButtonClicked() {
        hideWagonStory();
    }

    void showWagonStory() {
        wagonHideWindow.SetActive(true);
    }

    void hideWagonStory() {
        wagonHideWindow.SetActive(false);
    }




}
