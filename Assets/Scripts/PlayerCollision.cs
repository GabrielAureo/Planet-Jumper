using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
	public delegate void CollisionHandler(GameObject other);
	public static event CollisionHandler onPlatformHit;
	public static event CollisionHandler onBoundHit;
	public static event CollisionHandler onObstacleHit;

	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.root.tag == "MainCamera" && onBoundHit != null){
			onBoundHit(col.gameObject);
		}

		if(col.GetComponent<Platform>() != null && onPlatformHit != null){
			onPlatformHit(col.gameObject);
		}	
	}
}
