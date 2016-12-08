using UnityEngine;
using System.Collections;

    //Script for couple moving guards in the game. 
public class GuardMovement : MonoBehaviour {
    public float speed;
    private Animator animator;
    private bool flipGuard = true;
    private Rigidbody2D guardBody;

    //adding components and setting the guard animation true ( guards never stop ).
    void Start() {                       
        animator = GetComponent<Animator>();
        guardBody = GetComponent<Rigidbody2D>();
        guardBody.velocity = new Vector2(speed,0);
        animator.SetBool("GHorizAnim", true);
    }
  
    //guards cycle through waypoints.
    void OnTriggerEnter2D(Collider2D colli) {    
        if (colli.gameObject.tag=="Waypoint1") {
            guardBody.velocity = new Vector2(speed,0);
            GuardFlip(1);
        }
        if (colli.gameObject.tag == "Waypoint2") {
            guardBody.velocity = new Vector2(-speed, 0);
            GuardFlip(-1);
        }
    }

    //stops guards escaping to the void.
    void Update() { 
        transform.rotation = Quaternion.identity;
    }
    //Flips the guards animation when going left. 
    private void GuardFlip(int direction) { 
        if (direction > 0 && !flipGuard || direction < 0 && flipGuard) {
            flipGuard = !flipGuard;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
}
