using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;
using UnityEngine.SceneManagement;

//Controls the UI, pause menus and story windows, which will appear at the start of some scenes.

namespace Assets.Scripts {
    public class GameController : MonoBehaviour {

		bool playerDed = false;

        public static GameController instance= null;
        private GameObject Player;
        private GameObject playerStats;

        private Button menuButton;
        private Button mapButton;
        private Button bagButton;
        private Button statsButton;
        private Button enterButton;
		private Button hideStoryWindow;

		//These buttons show when you click "Menu" button
        private Button menuPlayButton;
        private Button menuQuitButton;

		//These objects control the UI submenus (minimap, stats, inventory and dialog)
        private GameObject Map;
        private GameObject Stats;
        private GameObject Bag;
        private GameObject DialogToggle;
        private GameObject Menu;
		private GameObject StoryWindow;
		private GameObject StoryWindowPrequel;

		//These objects are in the ''Game Over'' screen
		private GameObject GameOver;
		private Button ContinueButton;
		private Button QuitButton;

        private int frames = 0;

        public Player player;

        private Text statsText;
        private Text dialogText;

        private GameObject Interact;

        // Initialize all the game components necessary to control the player object and inventory, map etc.
        void Awake() {

            if (instance == null) {
                instance = this;
            } else if (instance != this) {
                Destroy(gameObject);
            }


			//Finds all of the UI Buttons and GameObjects and a story window button which is at the beginning of scenes
            enterButton = GameObject.Find("ButtonEnter").GetComponent<Button>();
            Bag = GameObject.Find("Bag");                                                                           // Initializes the Inventory
            mapButton = GameObject.Find("ButtonMap").GetComponent<Button>();                                        //   hides/shows map image. Uses a button method instead of ButtonController.
            Map = GameObject.Find("MapController");
            bagButton = GameObject.Find("ButtonBag").GetComponent<Button>();
            Stats = GameObject.Find("ShowStats");
            statsButton = GameObject.Find("ButtonStats").GetComponent<Button>();
            statsText = GameObject.Find("Stats").GetComponent<Text>();

			//This object(ShowDialog) controls the dialog box
            DialogToggle = GameObject.Find("ShowDialog");                                                        
            
			//This is the dialog box's text
			dialogText = GameObject.Find("ShowDialog").GetComponent<Text>();                                    
            
			//The interaction trigger spawned by the Enter button
			Interact = GameObject.Find("Player/Interact");
            
			//Objects for the "Pause menu"
			menuButton = GameObject.Find("ButtonMenu").GetComponent<Button>();
            menuPlayButton = GameObject.Find("ShowMenu/ResumeButton").GetComponent<Button>();
            menuQuitButton = GameObject.Find("ShowMenu/QuitButton").GetComponent<Button>();               
            
			//this object toggles the pause menu
			Menu = GameObject.Find("ShowMenu");                                                                 
            
			//Sets the functionality into the "game over" screen objects
			ContinueButton = GameObject.Find ("GameOverScreen/ContinueButton").GetComponent<Button> ();
			QuitButton = GameObject.Find("GameOverScreen/QuitButton").GetComponent<Button>();
            GameOver = GameObject.Find("GameOverScreen");


			if (SceneManager.GetActiveScene ().name.Equals ("Childhood room 1") || SceneManager.GetActiveScene().name.Equals("Sleeping Chambers") || SceneManager.GetActiveScene().name.Equals("Dungeon Level") || SceneManager.GetActiveScene().name.Equals("Second City") || SceneManager.GetActiveScene().name.Equals("Forest")) {

                StoryWindow = GameObject.Find ("StoryWindow");
				hideStoryWindow = GameObject.Find ("StoryWindow/ContinueButton").GetComponent<Button> ();

				//Activates another story window that display for a set amount of time
				if (SceneManager.GetActiveScene ().name.Equals ("Childhood room 1") || SceneManager.GetActiveScene().name.Equals("Sleeping Chambers") || SceneManager.GetActiveScene().name.Equals("Forest")) {

					StoryWindowPrequel = GameObject.Find ("StoryWindowPrequel");

					showPrequel ();
				
				}

				hideStoryWindow.onClick.AddListener (() => hideStory ());
			}


            Player = GameObject.Find("Player");                                                                  // playable character

            statsButton.onClick.AddListener(() => toggleStats());                                               // Calls a method to display stats window on UI
            mapButton.onClick.AddListener(() => toggleMap());                                                   // Calls a method on mouse click/touch input to hide/show minimap of the current scene
            bagButton.onClick.AddListener(() => toggleInventory());                                             // Calls a toggleInventory method to hide/show player's inventory
            enterButton.onClick.AddListener(() => searchInteraction());
            
			menuButton.onClick.AddListener(() => toggleMenu());
            menuPlayButton.onClick.AddListener(() => resumeGame());
			menuQuitButton.onClick.AddListener(() => quitGame());                //When you click "Quit to menu" button on the pause menu it returns you to the Title Menu

            ContinueButton.onClick.AddListener(() => ContinueGame());                //Continues game from Wench's House upstairs

			QuitButton.onClick.AddListener(() => quitToMainMenu());                    //Same thing here as in the pause menu^

            preventUIOverlap();

            cancelInteracting();


        }

        
        //Updates stats every 20th frame
        void Update() {
			
			//DELETE BEFORE RELEASE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
			if (StatKeeper.getHealth () <= 0) {//888888888888888888888888888888888888888888888888888888888888888888888888888
				StatKeeper.healPlayer ();//!111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111
			}///!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 

			frames++;

			if (frames % 60 == 0) { //If the remainder of the current frame divided by 60 is 0 run the function.

				UpdateStats ();

				if (StatKeeper.getHealth () <= 0) {

					Debug.Log ("Player Died !");


					if (!playerDed) {

						
						preventUIOverlap ();

						GameOver.SetActive (true);

						DialogToggle.SetActive (false);

						playerDed = true;

						StatKeeper.healPlayer();


					}

				}

			}
		}

		//Shows the prequel story window for 5 seconds, then invokes the hidePrequel method
		private void showPrequel() {
		
			Invoke ("hidePrequel", 5);
		
		}

		//Hides the story window
		private void hidePrequel() {

			StoryWindowPrequel.SetActive (false);

		}

		//Unfreezes the time and returns the player to main menu
		public void quitGame() {

			Time.timeScale = 1f;
			SceneManager.LoadScene (1);

		}

		//Hides the story window and continues the game
		void hideStory() {

			StoryWindow.SetActive (false);

		}

        //Continues the game and revives the player
        public void ContinueGame() {

			StatKeeper.healPlayer();

            Debug.Log("Continuing game from the checkpoint");

			StatKeeper.resetHoboCoin ();
			InventoryHandler.resetInventory (); 

			SceneManager.LoadScene (3);

        }

        //This allows user to interact with the environment
        private void searchInteraction() {

            Debug.Log("Player pressed Enter");

            Interact.SetActive(true);
            Invoke("cancelInteracting", 1);     //Waits for 1 second and then turns the interaction trigger off. 

        }

        private void cancelInteracting() {

            Interact.SetActive(false);

        }

        //This method quits to main menu and unfreezes time
        private void quitToMainMenu() {

            Time.timeScale = 1f;
            SceneManager.LoadScene(1);

        }

        //This method toggles the pause menu
        private void toggleMenu() {

            Debug.Log("Menu toggle");
            preventUIOverlap();

			DialogToggle.SetActive (false);

            if (Menu.activeSelf == true) {

                Menu.SetActive(false);

            } else {

                Time.timeScale = 0f;
                Menu.SetActive(true);

            }

        }

        // This method resumes gameplay in pause menu
        private void resumeGame() {

            Time.timeScale = 1f;
			DialogToggle.SetActive (true);
            preventUIOverlap();

        }

        //displays Minimap window on UI
        private void toggleMap() {                  //Method for showing/hiding minimap of the current scene

            Debug.Log("Map toggle");
            preventUIOverlap();             //Hiding other menus in order to avoid them overlapping

            if (Map.activeSelf == true) {

                Map.SetActive(false);
                statsText.text = StatKeeper.getStats();
            }
            else {

                Map.SetActive(true);

            }
        }

        //Displays Inventory window on UI
        private void toggleInventory() {

            Debug.Log("Inventory toggle");
            preventUIOverlap();             //Hiding other menus in order to avoid them overlapping

            if (Bag.activeSelf == true) {

                Bag.SetActive(false);

            }
            else {

                Bag.SetActive(true);

            }
        }

        // Displays Stats window on UI
       private void toggleStats() {


            preventUIOverlap();                                     //Hiding other menus in order to avoid them overlapping

            if (Stats.activeSelf == false) {

                statsText.text = StatKeeper.getStats();
                Stats.SetActive(true);
                


            } else {

                Stats.SetActive(false);

            }
        }

        private void UpdateStats() {

            statsText.text = StatKeeper.getStats();



        }


        //This method just disables all menus in order to prevent overlapping
        public void preventUIOverlap() {    

            if (Bag.activeSelf == true) {
                Bag.SetActive(false);
            }

            if (Map.activeSelf == true) {
                Map.SetActive(false);
            }

            if (Stats.activeSelf == true) {
                Stats.SetActive(false);
            }
            
            if(Menu.activeSelf == true) {
                 Menu.SetActive(false);

                }

            if(GameOver.activeSelf == true) {

                GameOver.SetActive(false);

                }
            }
        }
    }