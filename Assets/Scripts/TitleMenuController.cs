using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts {
    public class TitleMenuController : MonoBehaviour {

        private Button PlayButton;
        private Button AboutButton;
        private Button QuitButton;

        private GameObject ImageToggle;
        private GameObject AboutToggle;

        void Start() {

			Destroy (GameObject.Find("GameController"));
            Destroy(GameObject.Find("CheckForInteraction"));
            Destroy(GameObject.Find("InventoryHandler"));

            StatKeeper.ResetStats();
            InventoryHandler.resetInventory();

            PlayButton = GameObject.Find("Play").GetComponent<Button>(); 
            AboutButton = GameObject.Find("About").GetComponent<Button>();
            QuitButton = GameObject.Find("Quit").GetComponent<Button>();

            AboutToggle = GameObject.Find("AboutToggle");
            ImageToggle = GameObject.Find("ImageToggle");

            PlayButton.onClick.AddListener(() => startGame());
            AboutButton.onClick.AddListener(() => toggleAbout());
            QuitButton.onClick.AddListener(() => Application.Quit());

            AboutToggle.SetActive(false);

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
    }
}