using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {
	public delegate void CollisionHandler(GameObject other);
	public static event CollisionHandler onPlatformHit;
	public static event CollisionHandler onBoundHit;
	public static event CollisionHandler onObstacleHit;

	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.tag == "GameOver" /* && onBoundHit != null*/ ){
			//onBoundHit(col.gameObject);
			Debug.Log("Morreu");
			GameOverTest();

		}

		if(col.GetComponent<Platform>() != null && onPlatformHit != null){
			onPlatformHit(col.gameObject);
		}	
	}

	void GameOverTest(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
	}

	void OnDestroy()
	{	
		onBoundHit = null;
		onPlatformHit = null;
		onObstacleHit = null;
	}

}
