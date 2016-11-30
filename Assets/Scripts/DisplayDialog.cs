using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class DisplayDialog : MonoBehaviour {

        private Button Continue;
        private Text DialogBox;
        private GameObject Dialog;

        // Use this for initialization
        void Start() {

            Dialog = GameObject.Find("ShowDialog");
            DialogBox = GameObject.Find("DialogBox").GetComponent<Text>();

        }

        //Resumes time in the game
        public void ExitDialog() {

            if (!DialogBox.text.Equals("")) {
                Dialog.SetActive(false);
                Time.timeScale = 1.0f;
            } else { }
        }

        //Stops the time 
        private void startDialog() {

            Time.timeScale = 0f;

        }

        public void showDialog(string newDialog) {

            activateDialog();

            startDialog();

            Dialog.SetActive(true);
            DialogBox.text = newDialog;


        }

        public void activateDialog() {

            Dialog.SetActive(true);

        }


    }
}
