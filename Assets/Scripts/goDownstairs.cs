using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class goDownstairs : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("Player triggered level change");

        SceneManager.LoadScene(2);


    }
}

