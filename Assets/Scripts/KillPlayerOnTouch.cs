using UnityEngine;
using System.Collections;

// This class triggers the damaging action when the player falls into a pothole in the "Forest" scene.
// After damaging the player for 4hp, this script transforms the player back into the start of the forest scene.
namespace Assets.Scripts {
public class KillPlayerOnTouch : MonoBehaviour {

		private GameObject Player;

		Vector2 entrance = new Vector2(0.113f, -0.29f);

		void Awake() {

			Player = GameObject.Find ("Player");

		}
	
		void OnTriggerEnter2D(Collider2D colli) {
		
			if (colli.CompareTag ("Playa")) {
			
				StatKeeper.receiveDamage (4);

				Player.transform.position = entrance;
			
			}
		
		}
	}
}
