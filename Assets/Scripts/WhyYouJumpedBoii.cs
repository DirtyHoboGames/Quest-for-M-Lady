using UnityEngine;
using System.Collections;
using Assets.Scripts;
    
        //Dont jump off a cliff. (dungeon level script)
public class WhyYouJumpedBoii : MonoBehaviour {

    public AudioClip scream;
    private GameObject Player;
    Vector2 entrance = new Vector2(-16.108f, -5.782f);

    void Awake() {

        Player = GameObject.Find("Player");
    }

    void OnTriggerEnter2D(Collider2D colli) {

        if (colli.CompareTag("Playa")) {
            SoundManager.instance.musicSource.PlayOneShot(scream, 1.0f);
            StatKeeper.receiveDamage(10);
            Player.transform.position = entrance;
            
        }
    }
}

