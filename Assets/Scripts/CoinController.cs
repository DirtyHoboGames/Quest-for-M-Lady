using UnityEngine;
using System.Collections;
using Assets.Scripts;

namespace Assets.Scripts { 
    class CoinController : MonoBehaviour {

        public AudioClip coin;


        //When Player touches the HoboCoin, it disappears and calls a method to add one HoboCoin into the collectables
	    void OnTriggerEnter2D(Collider2D colli) {
			
			if (colli.CompareTag ("Playa")) {

                //SoundManager.instance.PlaySingle(coin);
                SoundManager.instance.musicSource.PlayOneShot(coin, 0.5f);
                //SoundManager.instance.PlaySingle(coin);

                Debug.Log("moi");

                DestroyObject(this.gameObject);

				StatKeeper.collectHoboCoin ();
			}
        }
	}
}
