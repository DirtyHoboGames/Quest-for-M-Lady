﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts {
    public class TitleMenuController : MonoBehaviour {

        private Button PlayButton;
        private Button AboutButton;
        private Button QuitButton;
        private Button HelpButton;
        private Button continueButton;

        private GameObject ImageToggle;
        private GameObject AboutToggle;
        private GameObject HelpToggle;

        void Start() {

			Destroy (GameObject.Find("GameController"));
            Destroy(GameObject.Find("CheckForInteraction"));
            Destroy(GameObject.Find("InventoryHandler"));

            StatKeeper.ResetStats();
            InventoryHandler.resetInventory();

            PlayButton = GameObject.Find("Play").GetComponent<Button>(); 
            AboutButton = GameObject.Find("About").GetComponent<Button>();
            QuitButton = GameObject.Find("Quit").GetComponent<Button>();
            HelpButton = GameObject.Find("Help").GetComponent<Button>();
            continueButton = GameObject.Find("HelpToggle/ContinueButton").GetComponent<Button>();

            AboutToggle = GameObject.Find("AboutToggle");
            ImageToggle = GameObject.Find("ImageToggle");
            HelpToggle = GameObject.Find("HelpToggle");

            continueButton.onClick.AddListener(() => startGame());

            PlayButton.onClick.AddListener(() => beginGame());
            AboutButton.onClick.AddListener(() => toggleAbout());
            QuitButton.onClick.AddListener(() => Application.Quit());
            HelpButton.onClick.AddListener(() => toggleHelp());

            AboutToggle.SetActive(false);
            HelpToggle.SetActive(false);
            continueButton.gameObject.SetActive(false);
            

        }

        //Shows the "How to play" text, disactivates Play, How to play, About and Quit buttons, activates Continue button and pauses the music. Pressing Continue starts the game

        void beginGame() {
            continueButton.gameObject.SetActive(true);
            PlayButton.gameObject.SetActive(false);
            AboutButton.gameObject.SetActive(false);
            QuitButton.gameObject.SetActive(false);
            HelpButton.gameObject.SetActive(false);
            QuitButton.gameObject.SetActive(false);
            ImageToggle.SetActive(false);
            HelpToggle.SetActive(true);
            SoundManager.instance.musicSource.Pause();

        }

        void startGame() {
         
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene + 1);

        }

        //Displays the About text
        void toggleAbout() {

            if(AboutToggle.activeSelf == true) {

                ImageToggle.SetActive(true);
                AboutToggle.SetActive(false);
                continueButton.gameObject.SetActive(false);


            } else {

                ImageToggle.SetActive(false);
                AboutToggle.SetActive(true);
                continueButton.gameObject.SetActive(false);

            }

        }

        //Displays the How to play text
        void toggleHelp() {

            if (HelpToggle.activeSelf == true) {

                ImageToggle.SetActive(true);
                HelpToggle.SetActive(false);


            } else {

                ImageToggle.SetActive(false);
                HelpToggle.SetActive(true);

            }

        }
    }
}