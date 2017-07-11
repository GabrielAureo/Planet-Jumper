using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerCollision.onHit += moveCamera;
	}
	
	// Update is called once per frame
	void moveCamera(GameObject target){
		Vector3 targetPos = new Vector3(target.transform.position.x,target.transform.position.y,transform.position.z);
		StartCoroutine(moveTo(targetPos));
	}

	IEnumerator moveTo(Vector3 target){
		float timeToStart = Time.time;

		while(Vector2.Distance(transform.position, target) > 0.05f){
			transform.position = Vector3.Lerp(transform.position, new Vector3(target.x,target.y, transform.position.z), (Time.time - timeToStart )* 0.3f );
			yield return null;
		}
		
	}
}
