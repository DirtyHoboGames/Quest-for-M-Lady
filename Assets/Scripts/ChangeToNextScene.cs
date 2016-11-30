using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Assets.Scripts {
    public class ChangeToNextScene : MonoBehaviour {

        //Makes the game load a next scene when player hits the trigger. Scene order can be seen from File - Built settings.
        void OnTriggerEnter2D(Collider2D col) {

            Debug.Log("Player triggered level change");

            int currentScene = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadScene(currentScene + 1);


        }
    }
}
