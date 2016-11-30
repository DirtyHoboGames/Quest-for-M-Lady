using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class Player {


        //Stores a player's name, health and Stats

        string playerName;
        //private Text allStats;

        //Here are the different stats, which are saved as int variables
        int Intelligence;
        int Charisma;
        int Strength;
        int Luck;

        //Our fabulous collectibles, that are found throughout our vast in-game universe !
        //public int HoboCoinsCollected = 0;

        //I think you can figure this out on your own
        int Health;

        //Constructor for a Player object
        public Player(string playerName, int Int, int Char, int Str, int Lck) {

            this.playerName = playerName;

            this.Intelligence = Int;
            this.Charisma = Char;
            this.Strength = Str;
            this.Luck = Lck;

            this.Health = 10;

        }

        //This method adds one collectable into HoboCoinsCollected Integer variable
        /* public void CollectHoboCoin() {

            Debug.Log("Player found a HoboCoin !");

            HoboCoinsCollected++;

        } */

        //This method makes our hero get slapped in the face and deals damage for an appropriate amount
        public void ReceiveDamage(int amount) {

            Debug.Log("An enemy deals damage for " + amount + " points" + "to Player !");

            this.Health -= amount;

        }

        //This method heals our hero back to full health, so he can keep on getting his ass kicked
        public void HealPlayer() {

            Debug.Log("Healing Player back to full health");

            this.Health = 10;

        }

        //This method sets our hero's Attributes, so he can get his ass kicked in a number of different ways
        public void SetStats(int Int, int Char, int Str, int Lck) {

           this.Intelligence = Int;
            this.Charisma = Char;
            this.Strength = Str;
            this.Luck = Lck;

            }

        //Collects all of the stats into a string, which is displayed in the stats window on UI
        public string DisplayStats() {

            int amount = StatKeeper.getCoinAmount();
            string temp = "" + 
     
                            "Health   " + this.Health + "\r\n\r\n" +
                            "Strength   " + this.Strength + "\r\n" +
                            "Charisma   " + this.Charisma + "\r\n" +
                            "Intelligence   " + this.Intelligence + "\r\n" +
                            "Luck   " + this.Luck + "\r\n" + 
                            "HoboCoins found    " + amount;

            return temp;

            }
        }
    }
