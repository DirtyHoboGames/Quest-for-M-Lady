using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;

public class HoboCoinDisplay : MonoBehaviour {

    private Text hobos;


    // Use this for initialization
    void Start() {

        hobos = GameObject.Find("HoboCoin/HoboCoinAmount").GetComponent<Text>();

    }

    // Update is called once per frame
    void Update() {

        hobos.text = StatKeeper.getHobos();

    }
}
