using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class WagonStoryWindow : MonoBehaviour {
    private Text dialog;
    private GameObject wagonStoryWindow;
    private GameObject wagonWindowTrigger;
    private Button YesButton;
    private Button NoButton;

    // Use this for initialization
    void Start() {

        wagonStoryWindow = GameObject.Find("WagonStoryWindow");
        YesButton = GameObject.Find("WagonStoryWindow/YesButton").GetComponent<Button>();
        NoButton = GameObject.Find("WagonStoryWindow/NoButton").GetComponent<Button>();
        YesButton.onClick.AddListener(() => YesButtonClicked());
        NoButton.onClick.AddListener(() => NoButtonClicked());
        wagonStoryWindow.SetActive(false);

    }

    void OnTriggerEnter2D(Collider2D colli) {

        if (colli.CompareTag("Playa")) {

            wagonStoryWindow.SetActive(true);
        }
    }

    void YesButtonClicked() {
        hideStory();
        InventoryHandler.GiveRose();
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }

    void NoButtonClicked() {
        hideStory();
    }

    void showStory() {
        wagonStoryWindow.SetActive(true);
    }

    void hideStory() {
        wagonStoryWindow.SetActive(false);
    }
}