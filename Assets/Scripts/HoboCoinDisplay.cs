using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;

        //Script for showing Hobo Coins in the upper left corner.
public class HoboCoinDisplay : MonoBehaviour {
        //dat hobos.
    private Text hobos;

    void Start() {
        //hobos
        hobos = GameObject.Find("HoboCoin/HoboCoinAmount").GetComponent<Text>();
    }
    // Update is called once per hobos
    void Update() {
        //hobos text is hobos number.
        hobos.text = StatKeeper.getHobos();
    }
}
//hobos