using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Platform {

	// Use this for initialization
	new void Start () {
		base.Start();
		gameObject.tag = "Enemy";
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		Vector2 randomDir = new Vector2(Random.Range(-1,1),Random.Range(-1,1)).normalized;
		if(randomDir == Vector2.zero)
			randomDir = Vector2.up;
		other.GetComponent<Rigidbody2D>().AddForce(randomDir *500);
		Destroy(gameObject);
	}
}
