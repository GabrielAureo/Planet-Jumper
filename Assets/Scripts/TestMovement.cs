using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour {
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
		Swipe.onLift += Throw;
	}

	void Throw (Vector2 angle){
		rb.velocity = Vector3.zero;
		rb.AddForce(angle * angle.magnitude);

	}
}
