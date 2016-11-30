using UnityEngine;
using System.Collections;

public class GuardMovement : MonoBehaviour {
    public float speed;
    private Animator animator;
    private bool flipGuard = true;
    private Rigidbody2D guardBody;

    void Start() {                       //adding components and setting the guard animation true ( guards never stop ).
        animator = GetComponent<Animator>();
        guardBody = GetComponent<Rigidbody2D>();
        guardBody.velocity = new Vector2(speed,0);
        animator.SetBool("GHorizAnim", true);
    }

    void OnTriggerEnter2D(Collider2D colli) {    //guards cycle through waypoints.
        if (colli.gameObject.tag=="Waypoint1") {
            guardBody.velocity = new Vector2(speed,0);
            GuardFlip(1);
        }
        if (colli.gameObject.tag == "Waypoint2") {
            guardBody.velocity = new Vector2(-speed, 0);
            GuardFlip(-1);
        }
    }
    void Update() { //stops guards escaping to the void.
        transform.rotation = Quaternion.identity;
    }
    private void GuardFlip(int direction) { //Flips the guards animation when going left. 
        if (direction > 0 && !flipGuard || direction < 0 && flipGuard) {
            flipGuard = !flipGuard;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
}
