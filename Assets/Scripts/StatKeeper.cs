using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Stat keeper.
/// 
/// Keeps all of the player's stats and health
/// </summary>



namespace Assets.Scripts {
    public class StatKeeper {

		static string selectedFather = "";

		static int discoveredDoggos;

		static int HoboCoinsCollected;

        static int Health;
        static int Charisma;
        static int Strength;
        static int Intelligence;
        static int Luck;

		static Dictionary<int,bool> doggos = new Dictionary<int,bool> ();

		/// <summary>
		/// executes at the start of this instance.
		/// </summary>

		static StatKeeper() {
		
			doggos.Add (17, false);
			doggos.Add (18, false);
			doggos.Add (19, false);
			doggos.Add (20, false);
			doggos.Add (21, false);
			doggos.Add (22, false);
			doggos.Add (23, false);
		
		}

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
        //Returns the amount of hobo coins as string.
        public static string getHobos() {
            string temp = HoboCoinsCollected.ToString();
            return temp;
        }

        //Returns the amount of health as string.
		public static string getHealthAmount() {
		
			string temp = Health.ToString ();

			return temp;
		
		}

		/// <summary>
		/// Doggos the discovered = checks if the doggo is already discovered, otherwise sets it as discovered and updates discoveredDoggos integer.
		/// </summary>
		/// <param name="doggonumber">Doggonumber.</param>
		public static void DoggoDiscovered(int doggonumber) {

			if (doggos [doggonumber]) {
				Debug.Log ("Already found this Doggo !");
			} else {

				markAsFound (doggonumber);

				discoveredDoggos++;

				Debug.Log ("Doggos found: " + discoveredDoggos);
			}
		}

		/// <summary>
		/// Marks the correct Doggo as found.
		/// </summary>
		/// <param name="doggo">Doggo.</param>
		private static void markAsFound(int doggo) {
		
			doggos [doggo] = true;
		
		}

		/// <summary>
		/// Gets the doggos.
		/// </summary>
		/// <returns>The doggos.</returns>
		public static string getDoggos() {
		
			string temp = discoveredDoggos.ToString ();

			return temp;
		
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
        /// Reset the stats
        /// </summary>
        public static void ResetStats() {

            setStats(10, 0, 0, 0, 0);

            selectedFather = "";

            resetHoboCoin();

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

			                       "Strength   " + Strength + "\r\n" +
			                       "Charisma   " + Charisma + "\r\n" +
			                       "Intelligence   " + Intelligence + "\r\n" +
			                       "Luck   " + Luck;

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


        /// <summary>
        /// returns the father that the player chose
        /// </summary>
        /// <returns></returns>
		public static string getFather() {
		
			Debug.Log ("Father is " + selectedFather);

			return selectedFather;

		
		}



        /// <summary>
        /// Saves the father selection that happens in the childhood scene
        /// </summary>
        /// <param name="father"></param>
		public static void SelectFather(string father) {
		
			selectedFather = father;
		
			Debug.Log ("Father selected: " + father);

		}

    }
}
