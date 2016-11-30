using UnityEngine;

namespace Assets.Scripts {
    class Fading {

        public Texture2D fadeOutTexture = Texture2D.blackTexture;        // Texture will overlay the screen. Can be image or a drawable graphic
        public float fadeSpeed = 0.2f;         // Fading speed

        private int drawDepth = -1000;          // Order in textures draw hierarchy; this will be at the top of the textures, since its the last texture to be rendered
        private float alpha = 1.0f;             //Textures alpha value between 1(fully visible) and 0 (Fully invisible)
        private int fadeDir = -1;               // The fading direction of the texture. Fade IN = -1, Fade OUT = 1

        void OnGUI () {
            // fade out/in the alpha value using a direction, a speed and Time.deltatime to convert the operation to seconds

            alpha += fadeDir * fadeSpeed * Time.deltaTime;

            //Force the number to be between 1 and 0 because GUI.color uses alpha value between 1 and 0

            alpha = Mathf.Clamp01(alpha);

            // set color of our GUI (in this case our image). All color values remain the same & the Alpha is set to the alpha variable

            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);            //Set the alpha value
            GUI.depth = drawDepth;                                                          //make the black texture render on top (= black texture is drawn last)
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);   //draw the texture to fill the whole screen


        }

        //sets fadeDir parameter making the scene fade IN = -1 or fade OUT = 1

        public float BeginFade(int direction) {

            fadeDir = direction;

            return (fadeSpeed);

        }

        //OnLevelWasLoaded is called when a level is loaded. It takes loaded level index (int) as a parameter so you can limit the fade in to certain scenes.
        public void OnLevelWasLoaded(int direction) {

            //BeginFade() sets now variable alpha = -1 so the scene fades IN

            BeginFade(direction);  

        }

    }
}
