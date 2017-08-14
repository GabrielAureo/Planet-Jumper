using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {
	public delegate void CollisionHandler(GameObject other);
	public static event CollisionHandler onPlatformHit;
	public static event CollisionHandler onGameOverHit;
	public static event CollisionHandler onObstacleHit;

	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.tag == "GameOver" /* && onBoundHit != null*/ ){
			GameOver.ResetGame();

		}

		if(col.GetComponent<Platform>() != null && onPlatformHit != null){
			onPlatformHit(col.gameObject);
		}	
	}

	

	void OnDestroy()
	{	
		onGameOverHit = null;
		onPlatformHit = null;
		onObstacleHit = null;
	}

}
