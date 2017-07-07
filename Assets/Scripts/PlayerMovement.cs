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
    }

    void Throw (Vector2 angle){
		rb.velocity = Vector3.zero;
		rb.AddForce(angle * angle.magnitude * force);

	}
}
