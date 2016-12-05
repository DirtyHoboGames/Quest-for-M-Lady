using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts {
    public class TitleMenuController : MonoBehaviour {

        private Button PlayButton;
        private Button AboutButton;
        private Button QuitButton;
        private Button HelpButton;

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

            AboutToggle = GameObject.Find("AboutToggle");
            ImageToggle = GameObject.Find("ImageToggle");
            HelpToggle = GameObject.Find("HelpToggle");

            PlayButton.onClick.AddListener(() => startGame());
            AboutButton.onClick.AddListener(() => toggleAbout());
            QuitButton.onClick.AddListener(() => Application.Quit());
            HelpButton.onClick.AddListener(() => toggleHelp());

            AboutToggle.SetActive(false);
            HelpToggle.SetActive(false);

        }

        void startGame() {

            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene + 1);

        }

        void toggleAbout() {

            if(AboutToggle.activeSelf == true) {

                ImageToggle.SetActive(true);
                AboutToggle.SetActive(false);


            } else {

                ImageToggle.SetActive(false);
                AboutToggle.SetActive(true);

            }

        }

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