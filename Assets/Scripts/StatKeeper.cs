using UnityEngine;
using System.Collections;

/// <summary>
/// Stat keeper.
/// 
/// Keeps all of the player's stats and health
/// </summary>
namespace Assets.Scripts {
    public static class StatKeeper {

		static string selectedFather = "";

        static int Health;
        static int Charisma;
        static int Strength;
        static int Intelligence;
        static int Luck;

        static int HoboCoinsCollected;

		/// <summary>
		/// Sets the stats.
		/// </summary>
		/// <param name="health">Health.</param>
		/// <param name="str">Strength.</param>
		/// <param name="chr">Charisma.</param>
		/// <param name="Int">Intelligence.</param>
		/// <param name="lck">Luck.</param>
        public static void setStats(int health, int str, int chr, int Int, int lck) {

            Debug.Log("Setting stats for player");

            Health = health;

            Strength = str;
            Charisma = chr;
            Intelligence = Int;
            Luck = lck;

        }

		/// <summary>
		/// Damages the player's Health
		/// </summary>
		/// <param name="amount">Amount.</param>
        public static void receiveDamage(int amount) {

            Debug.Log("Player receives damage for" + amount + " points");
            Health -= amount;

        }

		/// <summary>
		/// Heals the player.
		/// </summary>
        public static void healPlayer() {

            Debug.Log("Healing player back to full health");
            Health = 10;

        }

		/// <summary>
		/// Collects the hobo coin.
		/// </summary>
        //Whenever player picks up a HoboCoin, this method is called
        public static void collectHoboCoin() {

            Debug.Log("Player found a HoboCoin !");

            HoboCoinsCollected++;

        }

		/// <summary>
		/// Gets the coin amount.
		/// </summary>
		/// <returns>The coin amount.</returns>
        //Returns the amount of HoboCoins 
        public static int getCoinAmount() {

            return HoboCoinsCollected;

        }

		/// <summary>
		/// Gets the health.
		/// </summary>
		/// <returns>The health.</returns>
        //Returns player's health
        public static int getHealth() {

            return Health;

        }

		/// <summary>
		/// Gets the player's stats.
		/// </summary>
		/// <returns>The stats.</returns>
        //Collects all of the stats into a string, which is displayed in the stats window on UI
        public static string getStats() {

            string temp = "" +

                            "Health   " + Health + "\r\n\r\n" +
                            "Strength   " + Strength + "\r\n" +
                            "Charisma   " + Charisma + "\r\n" +
                            "Intelligence   " + Intelligence + "\r\n" +
                            "Luck   " + Luck + "\r\n" +
                            "HoboCoins found    " + HoboCoinsCollected;

            return temp;

        }

		public static void resetHoboCoin() {

			HoboCoinsCollected = 0;

		}

		/// <summary>
		/// Gets the player's strength.
		/// </summary>
		/// <returns>The strength.</returns>
		public static int getStrength() {

			return Strength;

		}

		/// <summary>
		/// Gets the player's charisma.
		/// </summary>
		/// <returns>The charisma.</returns>
		public static int getCharisma() {

			return Charisma;

		}

		/// <summary>
		/// Gets the player's luck.
		/// </summary>
		/// <returns>The luck.</returns>
		public static int getLuck() {

			return Luck;

		}

		public static string getFather() {
		
			Debug.Log ("Father is " + selectedFather);

			return selectedFather;

		
		}

		public static void SelectFather(string father) {
		
			selectedFather = father;
		
			Debug.Log ("Father selected: " + father);

		}

    }
}
