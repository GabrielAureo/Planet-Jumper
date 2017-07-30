using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Platform {

	Collider2D other;
	// Use this for initialization
	new void Start () {
		base.Start();
		gameObject.tag = "Enemy";
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		this.other = other;
		CameraController.finishedMoving += randomLaunch;
	}

	public void randomLaunch(){
		Vector2 randomDir = new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f)).normalized;
		Debug.Log("randomDir =" + randomDir);
		if(randomDir == Vector2.zero)
			randomDir = Vector2.up;
		other.GetComponent<Rigidbody2D>().AddForce(randomDir *500);
		Destroy(gameObject);
		CameraController.finishedMoving -= randomLaunch;
	}

	void OnDestroy()
	{
		CameraController.finishedMoving -= randomLaunch;
	}
}
