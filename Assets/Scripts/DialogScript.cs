using System.Collections.Generic;

    //Stores the NPC dialogs which will show up in the dialogbox of the UI. contains methods for getting the dialogs and also getting an empty dialog, which is for resetting the dialogbox
    //if the player presses enter and there are no interactable objects near him
namespace Assets.Scripts {
    public class DialogScript {

        private static List<string> dialogs = new List<string>();

        static DialogScript() {


            //M' Lady 0-2
            dialogs.Add("M' Lady \r\n   I haven't seen thee hither ere. What is thy nameth?");
            dialogs.Add("M' Lady \r\n   Typeth thy nameth");
            dialogs.Add("M' Lady \r\n   Nice to meeteth thee !. I am new at this nurs'ry and t is at each moment nice to meeteth new people. ");
            
            //Kindergarten nurse 3
			dialogs.Add("Nanny: \r\n\tWell seeth again tom'rrow dram one ! Hie to thy fath'r anon.");

            //other kid 4
            dialogs.Add("Doth not disturb me");

            //Random creepy kid 5
            dialogs.Add("Alas off thee dim-witt'd coyote !");

            //Wench 6-7
            dialogs.Add("Wench: \r\n   Oh? sweet rose.i'll alloweth to slideth.");
            dialogs.Add("Wench: \r\n   Geth lost garbage or thy will faceth certain death!");

            //M' Lady 8
			dialogs.Add("Holla th're !");

            //guard(s) 9 - 16
            dialogs.Add("Guard: \r\n	I hath used to beest an adventur'r liketh thee, but then i tooketh an arrow to the ham. ");
            dialogs.Add("Guard: \r\n	Grise aside, citizen");
        
            dialogs.Add("Guard: \r\n	Thee shant not pass!");
        
            dialogs.Add("Guard: \r\n	Receiveth hath lost, dog. ");
        
            dialogs.Add("Guard: \r\n	If 't be true i seeth thee again i shall murd'r thee in thy catch but a wink. ");
        
            dialogs.Add("Guard: \r\n	I see thee!! *Hits you*");
        
            dialogs.Add("Guard: \r\n	A n'rmal day h're isn't t citizen?");
        
            dialogs.Add("Guard: \r\n	I did see a frog this m'rning and t wast fabulous. ");

			// Doggo 17-24 

			dialogs.Add ("Doggo:\r\n\tWoof !");
			dialogs.Add ("Doggo:\r\n\tThe French Revolution (French: Révolution française [ʁevɔlysjɔ̃ fʁɑ̃sɛːz]) was a period of far-reaching social and political upheaval in France that lasted from 1789 until 1799, and was partially carried forward by Napoleon during the later expansion of the French Empire. The Revolution overthrew the monarchy, established a republic, experienced violent periods of political turmoil, and finally culminated in a... dictatorship under Napoleon.");
			dialogs.Add ("Doggo:\r\n\tThe M60 is a belt-fed machine gun that fires the 7.62×51mm NATO cartridge (.308 Winchester) commonly used in larger rifles. It is generally used as a crew-served weapon and operated by a team of two or three individuals. The team consists of the gunner, the assistant gunner (AG in military slang), and the ammunition bearer. The gun's weight and the amount of ammunition it can consume when fired make...\t\t it difficult for a single soldier to carry and operate. The gunner carries the weapon and, depending on his strength and stamina, anywhere from 200 to 1000 rounds of ammunition. The assistant carries a spare barrel and extra ammunition, and reloads and spots targets for the gunner. The ammunition bearer carries additional ammunition and the tripod with associated traversing and elevation mechanism, if issued, and fetches more ammunition as needed during firing.");
			dialogs.Add ("Doggo:\r\n\tA man escaped from a German prison by hiding in a cardboard box, which was then taken outside of the prison by courier.");
			dialogs.Add ("Doggo:\r\n\tI once hid in that haywagon, but you didn't hear it from me");
			dialogs.Add ("Doggo:\r\n\tMuch coin, such wow !");
			dialogs.Add ("Doggo:\r\n\tNewton's laws of motion are three physical laws that, together, laid the foundation for classical mechanics. They describe the relationship between a body and the forces acting upon it, and its motion in response to those forces. They have been expressed in several different ways, over nearly three centuries, and can be summarised as follows. First law: In an inertial reference frame, an object either remains at rest or continues... to move at a constant velocity, unless acted upon by a net force.[2][3] Second law: In an inertial reference frame, the vector sum of the forces F on an object is equal to the mass m of that object multiplied by the acceleration a of the object: F = ma. Third law: When one body exerts a force on a second body, the second body simultaneously exerts a force equal in magnitude and opposite in direction on the first body.");
			dialogs.Add ("Doggo:\r\n\tLooking for the last coin, eh ? Here you go !");


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
