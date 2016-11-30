using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts { 
public class InventoryHandler : MonoBehaviour {

        private static bool roseUsed = false;
        private static bool potionsUsed = false;

        private Text potionText;
        private static int potionAmount = 3;

        private Button ButtonPotion;
        private Button ButtonRose;

        private GameObject Potion;
        private GameObject Rose;

        
        // Use this for initialization
        void Start () {


        potionText = GameObject.Find("ItemPotion/Text").GetComponent<Text>();

        ButtonPotion = GameObject.Find("ItemPotion/ButtonPotion").GetComponent<Button>();
        ButtonRose = GameObject.Find("ItemRose/ButtonRose").GetComponent<Button>();

        Potion = GameObject.FindGameObjectWithTag("Potion");
        Rose = GameObject.FindGameObjectWithTag("Rose");

        ButtonPotion.onClick.AddListener(() => usePotion());
        ButtonRose.onClick.AddListener(() => useRose());

            OnLevelWasLoaded(SceneManager.GetActiveScene().buildIndex);



        }

        void Update() {
            if (roseUsed == true) {
                useRose();
            }
        }

        //Checks if the potions & rose has been already used
        void OnLevelWasLoaded(int level) {

            if (potionsUsed) {

                if (Potion.activeSelf == false) { }

                else {

                    Potion.SetActive(false);

                }

            }

            if (roseUsed) {

                Rose.SetActive(false);

            }

        }

        //Uses one potion and heals the player back to full health
        public void usePotion() {

            if (potionAmount > 1 && potionAmount != 0) {

                potionAmount--;
                Debug.Log("Potions left :" + potionAmount);
                StatKeeper.healPlayer();
                potionText.text = "Potion (" + potionAmount + ")";

            } else if(potionAmount == 1) {

                potionAmount--;
                StatKeeper.healPlayer();
                potionText.text = "Potion (" + potionAmount + ")";
                potionsUsed = true;
                Potion.SetActive(false);

            } else {

                Potion.SetActive(false);

            }
        }

        //Uses the rose, if you really want to do it
        public void useRose() {

            roseUsed = true;
            Debug.Log("Rose used... U gonna regret it m8");
            Rose.SetActive(false);

        }

        public static int getPotionAmount() {

            return potionAmount;

        }

        public static void GiveRose() {
            roseUsed = true;
        }

		public static bool roseAlreadyUsed() {
		
			return roseUsed;
		
		}

        public static void resetInventory() {

            roseUsed = false;

            potionAmount = 3;

            potionsUsed = false;

        }
    }
}
