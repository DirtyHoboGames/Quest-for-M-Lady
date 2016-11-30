using UnityEngine;
using System.Collections;

//Controls the story boxes in the final scene
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace Assets.Scripts {
public class Ending : MonoBehaviour {

		private GameObject EndIntro;
		private Button Strength;
		private Button Luck;
		private Button Charisma;

		private GameObject EndStrGood;
		private Button StrGoodContinue;

		private GameObject EndStrBad;
		private Button StrBadLoad;

		private GameObject EndLckGood;
		private Button LckGoodContinue;

		private GameObject EndLckBad;
		private Button LckBadLoad;

		private GameObject EndChrGood;
		private Button ChrGoodContinue;

		private GameObject EndChrBad;
		private Button ChrBadLoad;

		private GameObject EnterCastle;
		private Button EnterCastleContinue;

		private GameObject MladyIntro;
		private Button GiveRoseButton;
		private Button NoButton;

		private GameObject MladyGood;
		private Button GoodEndingButton;

		private GameObject MladyBad;
		private Button BadEndingButton;

        private GameObject GoodEnding;
        private GameObject BadEnding;

		//Assings the class variables to the correct gameobjects at the start of the scene
		void Start() {

			EndIntro = GameObject.Find ("EndIntro");
			Strength = GameObject.Find ("EndIntro/Strength").GetComponent<Button> ();
			Luck = GameObject.Find ("EndIntro/Luck").GetComponent <Button> ();
			Charisma = GameObject.Find ("EndIntro/Charisma").GetComponent<Button> ();

			EndStrGood = GameObject.Find ("EndStrGood");
			StrGoodContinue = GameObject.Find ("EndStrGood/ContinueButton").GetComponent<Button> ();

			EndStrBad = GameObject.Find ("EndStrBad");
			StrBadLoad = GameObject.Find ("EndStrBad/LoadButton").GetComponent<Button> ();

			EndLckGood = GameObject.Find ("EndLckGood");
			LckGoodContinue = GameObject.Find ("EndLckGood/ContinueButton").GetComponent<Button> ();

			EndLckBad = GameObject.Find ("EndLckBad");
			LckBadLoad = GameObject.Find ("EndLckBad/LoadButton").GetComponent<Button> ();

			EndChrGood = GameObject.Find ("EndChrGood");
			ChrGoodContinue = GameObject.Find ("EndChrGood/ContinueButton").GetComponent<Button> ();

			EndChrBad = GameObject.Find ("EndChrBad");
			ChrBadLoad = GameObject.Find ("EndChrBad/LoadButton").GetComponent<Button> ();

			EnterCastle = GameObject.Find ("EnterCastle");
			EnterCastleContinue = GameObject.Find ("EnterCastle/ContinueButton").GetComponent<Button> ();

			MladyIntro = GameObject.Find("MladyIntro");
			GiveRoseButton = GameObject.Find("GiveRoseButton").GetComponent<Button>();
			NoButton = GameObject.Find("NoButton").GetComponent<Button>();

			MladyGood = GameObject.Find("MladyGood");
			GoodEndingButton = GameObject.Find("GoodEndingButton").GetComponent<Button>();

			MladyBad = GameObject.Find("MladyBad");
			BadEndingButton = GameObject.Find("BadEndingButton").GetComponent<Button>();

            GoodEnding = GameObject.Find("GoodEnding");
            BadEnding = GameObject.Find("BadEnding");

			//First story window choices
			Strength.onClick.AddListener (() => traitSelected ("Strength"));
			Luck.onClick.AddListener (() => traitSelected ("Luck"));
			Charisma.onClick.AddListener (() => traitSelected ("Charisma"));

			//second story window victory buttons
			StrGoodContinue.onClick.AddListener(() => continueStory(1));
			LckGoodContinue.onClick.AddListener(() => continueStory(1));
			ChrGoodContinue.onClick.AddListener(() => continueStory(1));

			//Second story window death buttons
			StrBadLoad.onClick.AddListener(() => restartLevel());
			LckBadLoad.onClick.AddListener(() => restartLevel());
			ChrBadLoad.onClick.AddListener(() => restartLevel());

			EnterCastleContinue.onClick.AddListener(() => continueStory(2));

			GiveRoseButton.onClick.AddListener (() => continueStory (3));

			NoButton.onClick.AddListener (() => continueStory (4));

			GoodEndingButton.onClick.AddListener (() => continueStory (5));

			BadEndingButton.onClick.AddListener (() => continueStory (6));

			disableAllWindows ();


		}

		void OnTriggerEnter2D(Collider2D colli) {
		
			if (colli.CompareTag ("Playa")) {
			
				EndIntro.SetActive (true);
			
			}
		
		}

		//Continues the story onward
		/* private void continueStory(int window) {

			if (window == 1) {

				disableAllWindows ();

				EnterCastle.SetActive (true);
			}

			if (window == 2) {
			
				disableAllWindows ();
			
				MladyIntro.SetActive (true);

			}

			if (window == 3) {
			
				disableAllWindows ();

				MladyGood.SetActive (true);
			
			}

			if (window == 4) {
			
				disableAllWindows ();

				MladyBad.SetActive (true);
			
			}

		} */

		//Continues the story onward based on players choices
		private void continueStory(int window) {

			int switchValue = window;

			switch(switchValue) {

			case 1:

				disableAllWindows ();

				EnterCastle.SetActive (true);

				break;

			case 2:

				disableAllWindows ();

				if (InventoryHandler.roseAlreadyUsed ()) {
				
					GiveRoseButton.enabled = false;
				
				}

				MladyIntro.SetActive (true);

				break;

			case 3: 

				disableAllWindows ();

				MladyGood.SetActive (true);

				break;

			case 4:

				disableAllWindows ();

				MladyBad.SetActive (true);

				break;

			case 5:

				disableAllWindows ();

                    GoodEnding.SetActive(true);

                    Invoke("theEnd", 10);

				break;

			case 6:

				disableAllWindows ();

                    BadEnding.SetActive(true);

                    Invoke("theEnd", 10);

				break;

			}
		}

        //Loads the main menu after the ending
        private void theEnd() {

            SceneManager.LoadScene(1);

        }



		//Checks which trait is selected and compares it to selected father. Activates story windows accordingly.
		private void traitSelected(string skill) {


			if (skill.Equals ("Strength")) {

				if (skill.Equals (StatKeeper.getFather())) {

					EndIntro.SetActive (false);

					EndStrGood.SetActive (true);
				
				} else {

					EndIntro.SetActive (false);

					EndStrBad.SetActive (true);

				}
			
			}

			if (skill.Equals ("Luck")) {

				if (skill.Equals (StatKeeper.getFather())) {

					EndIntro.SetActive (false);

					EndLckGood.SetActive (true);

				} else {

					EndIntro.SetActive (false);

					EndLckBad.SetActive (true);

				}

			
			}

			if (skill.Equals ("Charisma")) {

				if (skill.Equals (StatKeeper.getFather())) {

					EndIntro.SetActive (false);

					EndChrGood.SetActive (true);

				} else {

					EndIntro.SetActive (false);

					EndChrBad.SetActive (true);

				}
			
			}
		
		}

		//Disables all story windows
		private void disableAllWindows() {

			if (EndIntro.activeSelf) {

				EndIntro.SetActive (false);

			}

			if (EndStrGood.activeSelf) {

				EndStrGood.SetActive (false);

			}

			if (EndStrBad.activeSelf) {

				EndStrBad.SetActive (false);

			}

			if (EndLckGood.activeSelf) {

				EndLckGood.SetActive (false);

			}

			if (EndLckBad.activeSelf) {

				EndLckBad.SetActive (false);

			}

			if (EndChrGood.activeSelf) {

				EndChrGood.SetActive (false);

			}

			if (EndChrBad.activeSelf){
				
				EndChrBad.SetActive(false);

			}

			if (EnterCastle.activeSelf){
				
				EnterCastle.SetActive(false);

			}

			if (MladyIntro.activeSelf) {
			
				MladyIntro.SetActive (false);
			
			}

			if (MladyGood.activeSelf) {

				MladyGood.SetActive (false);

			}

			if (MladyBad.activeSelf) {

				MladyBad.SetActive (false);

			}

            if(GoodEnding.activeSelf) {

                GoodEnding.SetActive(false);

            }

            if(BadEnding.activeSelf) {

                BadEnding.SetActive(false);

            }

		}

		private void restartLevel(){

			int currentScene = SceneManager.GetActiveScene ().buildIndex;
			SceneManager.LoadScene (currentScene);

		}


	}
}
