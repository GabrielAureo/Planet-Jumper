using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : Obstacle {

	Action<Rigidbody2D> shouldPull;
	Rigidbody2D target;

	public float pullForce;

	void Start(){
		gameObject.tag = "BlkHole";
	}

	void Update(){
		if(shouldPull != null) shouldPull(target);
	}

    protected override void onHit(Collider2D other)
    {
		target = other.GetComponent<Rigidbody2D>();
		shouldPull = pullToCenter;
        
    }

	void pullToCenter(Rigidbody2D rb){
		float dist = Vector2.Distance((Vector2)transform.position, (Vector2)rb.position);
		Vector2 v = (Vector2)transform.position - (Vector2)rb.position;
		rb.AddForce (v.normalized * pullForce * Time.deltaTime);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		shouldPull = null;
	}
}