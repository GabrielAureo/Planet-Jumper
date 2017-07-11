using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	Rigidbody2D rb;
    public float force;

	// Use this for initialization
	void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Swipe.onLift += Throw;
        PlayerCollision.onHit += Stop;
    }
    void Update(){
        //transform.localScale = Vector3.one + Vector3.one * (1/PlanetsGenerator.plane.z)*(PlanetsGenerator.plane.x * transform.position.x + PlanetsGenerator.plane.y * transform.position.y);

    }

    void Throw (Vector2 angle){
		rb.velocity = Vector3.zero;
		rb.AddForce(angle * angle.magnitude * force);
	}

    void Stop(GameObject etc){
        rb.velocity = Vector2.zero;
    }
}
