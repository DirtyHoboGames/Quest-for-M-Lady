using System.Collections.Generic;

    //Stores the NPC dialogs which will show up in the dialogbox of the UI. contains methods for getting the dialogs and also getting an empty dialog, which is for resetting the dialogbox
    //if the player presses enter and there are no interactable objects near him
namespace Assets.Scripts {
    public class DialogScript {

        private static List<string> dialogs = new List<string>();

        public static void DialogInit() {


            //M' Lady 0-2
            dialogs.Add("M' Lady \r\n   I haven't seen thee hither ere. What is thy nameth?");
            dialogs.Add("M' Lady \r\n   Typeth thy nameth");
            dialogs.Add("M' Lady \r\n   Nice to meeteth thee !. I am new at this nurs'ry and t is at each moment nice to meeteth new people. ");
            
            //Kindergarten nurse 3
			dialogs.Add("Well seeth again tom'rrow dram one ! Hie to thy fath'r anon.");

            //other kid 4
            dialogs.Add("Doth not disturb me");

            //Random creepy kid 5
            dialogs.Add("Alas off thee dim-witt'd coyote !");

            //Wench 6-7
            dialogs.Add("Wench \r\n   Oh? sweet rose.i'll alloweth t slideth.");
            dialogs.Add("Wench \r\n   Geth lost garbage or thy will faceth certain death!");

            //M' Lady 8
			dialogs.Add("Holla th're !");

            //guard(s) 9 - infinitii
            dialogs.Add("Guard: \r\n	I hath used to beest an adventur'r liketh thee, but then i tooketh an arrow to the ham. ");
            dialogs.Add("Guard: \r\n	Grise aside, citizen");
        
            dialogs.Add("Guard: \r\n	Thee shant not pass!");
        
            dialogs.Add("Guard: \r\n	Receiveth hath lost, dog. ");
        
            dialogs.Add("Guard: \r\n	If 't be true i seeth thee again i shall murd'r thee in thy catch but a wink. ");
        
            dialogs.Add("Guard: \r\n	I see thee!! *Hits you*");
        
            dialogs.Add("Guard: \r\n	A n'rmal day h're isn't t citizen?");
        
            dialogs.Add("Guard: \r\n	I did see a frog this m'rning and t wast fabulous. ");
        }
        //returns the correct dialog based on NPC's name, which acts a index for the "dialogs" list
        public static string getDialog (int lel) {

            if(dialogs.Count > lel) {
            return dialogs[lel];
        } else {
            return "not found";
        }
    }
		//returns empty dialog to clear the dialog box when you aren't near anything/anyone
		public static string getNullDialog() {

			return "";
        }
    }
}
