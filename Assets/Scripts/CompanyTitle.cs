using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Assets.Scripts {
    public class CompanyTitle : MonoBehaviour {

        // Displays our awesome company logo for 5 seconds and then switches to Title menu
        void Start() {

            Invoke("LoadNextScene", 5);

        }

        //Loads next scene
        void LoadNextScene() {

            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene + 1);
                
        }
    }
}