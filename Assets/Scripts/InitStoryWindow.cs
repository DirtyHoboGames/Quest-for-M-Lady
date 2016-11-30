using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Initializes the story window in the ''first city'' scene
namespace Assets.Scripts {
public class InitStoryWindow : MonoBehaviour {

		private GameObject storyWindow;
		private Button continueButton;
		private GameObject storyWindowTrigger;

	// Use this for initialization
	void Start () {
	

			storyWindow = GameObject.Find("StoryWindow");
			continueButton = GameObject.Find("StoryWindow/ContinueButton").GetComponent<Button>();

			continueButton.onClick.AddListener(() => resumeGame());
		
			storyWindow.SetActive (false);

			storyWindowTrigger = GameObject.Find ("StoryWindowTrigger");

	}

		void resumeGame() {

			storyWindow.SetActive (false);

			storyWindowTrigger.SetActive (false);

		}

		/// <summary>
		/// Raises the triggerenter2D event StoryWindow()
		/// </summary>
		/// <param name="colli">Colli.</param>
		void OnTriggerEnter2D(Collider2D colli) {

			if (colli.CompareTag ("Playa")) {
			
				storyWindow.SetActive (true);

			
			}

		}
	}
}