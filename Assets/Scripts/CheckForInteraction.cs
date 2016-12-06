using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets;
using UnityEngine.SceneManagement;

// When player presses the enter button, it checks if there are any interactable NPC's  near the player
//If there is, it gets the dialog from the dialog script according to the NPC index 
//It also includes functionality for finding hidden hobocoins in the walls, crates etc..
//Also controls the childhood scene's father selection.
using System;

namespace Assets.Scripts {
	
    public class CheckForInteraction : MonoBehaviour {

        private bool inConversation;

        private Text dialog;

        public AudioClip doggo;
        public AudioClip yellowKnight;
        public AudioClip blueKnight;
        public AudioClip bloodyKnight;

		//These objects show if you press Enter near the Yellow Knight
		private GameObject YellowKnightToggle;
		private Button YellowNo;
		private Button YellowYes;

		//These objects show if you press Enter near the Blue Knight
		private GameObject BlueKnightToggle;
		private Button BlueYes;
		private Button BlueNo;

		//These objects show if you press Enter near the Bloody Knight
		private GameObject BloodyKnightToggle;
		private Button BloodyYes;
		private Button BloodyNo;

        public static List<string> dialogs = new List<string>();

		void Awake() {


            dialog = GameObject.Find("ShowDialog/DialogBox").GetComponent<Text>();
            

			if (SceneManager.GetActiveScene().name.Equals ("Childhood room 1")) {

				StatKeeper.setStats (5, 0, 0, 0, 0);

				//Finds the objects and assings the correct methods if you click the buttons
				YellowKnightToggle = GameObject.Find ("YellowKnightToggle");
				YellowYes = GameObject.Find ("YellowKnightToggle/YesButton").GetComponent<Button> ();
				YellowNo = GameObject.Find ("YellowKnightToggle/NoButton").GetComponent<Button> ();

				BlueKnightToggle = GameObject.Find ("BlueKnightToggle");
				BlueYes = GameObject.Find ("BlueKnightToggle/YesButton").GetComponent<Button> ();
				BlueNo = GameObject.Find ("BlueKnightToggle/NoButton").GetComponent<Button> ();

				BloodyKnightToggle = GameObject.Find ("BloodyKnightToggle");
				BloodyYes = GameObject.Find ("BloodyKnightToggle/YesButton").GetComponent<Button> ();
				BloodyNo = GameObject.Find ("BloodyKnightToggle/NoButton").GetComponent<Button> ();

				YellowYes.onClick.AddListener (() => FatherSelected ("Yellow"));
				YellowNo.onClick.AddListener (() => resumeGame ());

				BlueYes.onClick.AddListener (() => FatherSelected ("Blue"));
				BlueNo.onClick.AddListener (() => resumeGame ());

				BloodyYes.onClick.AddListener (() => FatherSelected ("Bloody"));
				BloodyNo.onClick.AddListener (() => resumeGame ());


					toggleFathers ();
			}

        }

		void OnTriggerEnter2D(Collider2D colli) {

			if (colli.CompareTag ("Doggo")) {

                SoundManager.instance.musicSource.PlayOneShot(doggo, 1.0f);

                dialog.text = DialogScript.getDialog (int.Parse (colli.gameObject.name));

				StatKeeper.DoggoDiscovered (int.Parse(colli.gameObject.name));

			}

			if (colli.CompareTag ("NPC")) {

				dialog.text = DialogScript.getDialog (int.Parse (colli.gameObject.name));


			} else if (colli.CompareTag ("HiddenHoboCoin") == true) {

				Debug.Log ("Oh look, a HoboCoin !");

				StatKeeper.collectHoboCoin ();

			} else if (colli.CompareTag ("HostileNPC") == true) {

				StatKeeper.receiveDamage (2);

			} else if (colli.CompareTag ("YellowKnight") == true) {

                if (YellowKnightToggle.activeSelf == false) {

                    SoundManager.instance.musicSource.PlayOneShot(yellowKnight, 1.0f);

                    toggleFathers();
					
					YellowKnightToggle.SetActive (true);
				}


			} else if (colli.CompareTag ("BlueKnight") == true) {

				if (BlueKnightToggle.activeSelf == false) {

                    SoundManager.instance.musicSource.PlayOneShot(blueKnight, 1.0f);

                    toggleFathers();
					
					BlueKnightToggle.SetActive (true);
				}


			} else if (colli.CompareTag ("BloodyKnight") == true) {
				
				if (BloodyKnightToggle.activeSelf == false) {

                    SoundManager.instance.musicSource.PlayOneShot(bloodyKnight, 1.0f);

                    toggleFathers();
					
					BloodyKnightToggle.SetActive (true);
				}

			} else {
				
					toggleFathers ();

				dialog.text = DialogScript.getNullDialog ();

			}
				
        }

		//resumes the game when the player doesn't want this father
		void resumeGame() {

			if (YellowKnightToggle.activeSelf == true) {
				YellowKnightToggle.SetActive(false);
			}

			if (BlueKnightToggle.activeSelf == true) {
				BlueKnightToggle.SetActive(false);
			}

			if (BloodyKnightToggle.activeSelf == true) {
				BloodyKnightToggle.SetActive(false);
			}
		}

		//When the player selects the father, this method sets the correct father into the StatKeeper 
		void FatherSelected(string father) {

			if (father.Equals ("Yellow")) {

				StatKeeper.setStats (10, 4, 7, 5, 4);

				StatKeeper.SelectFather ("Charisma");

				int temp = SceneManager.GetActiveScene().buildIndex;

                toggleFathers();

				SceneManager.LoadScene(temp + 1);

			} else if (father.Equals ("Blue")) {
			
				StatKeeper.setStats (10, 4, 4, 5, 7);

				StatKeeper.SelectFather ("Luck");

				int temp = SceneManager.GetActiveScene().buildIndex;

                toggleFathers();

				SceneManager.LoadScene(temp + 1);
			
			} else if (father.Equals ("Bloody")) {

				StatKeeper.setStats (10, 7, 4, 5, 4);

				StatKeeper.SelectFather ("Strength");

				int temp = SceneManager.GetActiveScene().buildIndex;

                toggleFathers();

				SceneManager.LoadScene(temp + 1);

				}
			}
			
			//Prevents overlapping of the UI layers
			void toggleFathers() {
			
				if(YellowKnightToggle.activeSelf == true) {

					YellowKnightToggle.SetActive(false);

				}

				if(BloodyKnightToggle.activeSelf == true) {

					BloodyKnightToggle.SetActive(false);

				}

				if(BlueKnightToggle.activeSelf == true) {

					BlueKnightToggle.SetActive(false);

			}
		}

    }
}