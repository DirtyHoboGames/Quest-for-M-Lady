using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.UI;
namespace Assets.Scripts {
    public class PlayerMovement : MonoBehaviour {

        private ButtonController upButton;
        private ButtonController downButton;
        private ButtonController rightButton;
        private ButtonController leftButton;
        private Animator animator;
        private bool flipPlayer = true;
        private Rigidbody2D body;
        public float velocityMultiplier;
          
        // Use this for initialization
        void Start() {

            downButton = GameObject.Find("ButtonDown").GetComponent<ButtonController>();        //  Controls
            upButton = GameObject.Find("ButtonUp").GetComponent<ButtonController>();            //  the
            rightButton = GameObject.Find("ButtonRight").GetComponent<ButtonController>();      //  players
            leftButton = GameObject.Find("ButtonLeft").GetComponent<ButtonController>();        //  movement & uses ButtonController class
            body = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();

        }

        // Update is called once per frame
        void FixedUpdate() {

            if (!upButton.GetPressed() && !downButton.GetPressed() && !leftButton.GetPressed() && !rightButton.GetPressed()) {
                body.velocity = new Vector2(0, 0);
            }

            if (upButton.GetPressed()) {
                MovePlayer("up");
                animator.SetBool("WalkUp", true);
            } else {
                animator.SetBool("WalkUp", false);
            }
            if (downButton.GetPressed()) {
                MovePlayer("down");
                animator.SetBool("WalkDown", true);
            } else {
                animator.SetBool("WalkDown", false);
            }
            if (rightButton.GetPressed()) {
                MovePlayer("right");
                animator.SetBool("WalkHorizontal", true);
                PlayerFlip(1);
            } 
            else if (leftButton.GetPressed()) {
                MovePlayer("left");
                animator.SetBool("WalkHorizontal", true);
                PlayerFlip(-1);
            } else {
                animator.SetBool("WalkHorizontal", false);
            }
            transform.rotation = Quaternion.identity;
        }
        private void PlayerFlip(int direction) {
            if (direction > 0 && !flipPlayer || direction < 0 && flipPlayer) {
                flipPlayer = !flipPlayer;
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
        }
        public void MovePlayer(string direction) {                 //Method for moving the player character

            if (direction.Equals("up")) {
                body.velocity = new Vector2(0,velocityMultiplier);
                //transform.Translate(0, 0.02f, 0);
            }
            else if (direction.Equals("down")) {
                body.velocity = new Vector2(0,-velocityMultiplier);
                //transform.Translate(0, -0.02f, 0);
            }
            else if (direction.Equals("left")) {
                body.velocity = new Vector2(-velocityMultiplier, 0);
                //transform.Translate(-0.02f, 0, 0);
            }
            else if (direction.Equals("right")) {
                body.velocity = new Vector2(velocityMultiplier, 0);
                //transform.Translate(0.02f, 0, 0);
            } 
            
        }

      /* void OnTriggerEnter2D(Collider2D colli) {
            if (colli.gameObject.name == "HoboCoin") {

                GameController.instance.player.CollectHoboCoin(); 

            }    
            
        }   */
    }
}