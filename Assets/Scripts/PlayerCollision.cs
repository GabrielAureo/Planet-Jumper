using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
	public delegate void CollisionHandler(Vector2 otherPos);
	public static event CollisionHandler onHit;

	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D col)
	{
		if(onHit != null){
			onHit(col.transform.position);
		}	
	}
}
