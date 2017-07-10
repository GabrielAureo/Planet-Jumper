using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerCollision.onHit += moveCamera;
	}
	
	// Update is called once per frame
	void moveCamera(Vector2 target){
		transform.position = new Vector3(target.x, target.y, transform.position.z);
	}

	IEnumerator move(Vector2 target){

		while((Vector2)transform.position != target){
			transform.position = Vector3.Lerp(transform.position, new Vector3(target.x,target.y, transform.position.z), 0.2f);
		}
		yield return null;
	}
}
