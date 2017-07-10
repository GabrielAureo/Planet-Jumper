using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe: MonoBehaviour {
	Vector2 clickPos;
	Vector2 currentPos;
	[SerializeField]
	float angle;

	public delegate void mouseClickHandler(Vector2 pos);
	public static event mouseClickHandler onClick;

	public delegate void mouseHoldHandler(Vector2 pos);
	public static event mouseHoldHandler onHold;

	public delegate void mouseLiftHandler(Vector2 pos);
	public static event mouseLiftHandler onLift;

	
	void Update(){
		if(Input.GetMouseButtonDown(0)){
			clickPos = GetWorldPositionOnPlane(Input.mousePosition,0);
			Debug.Log(clickPos);
			if(onClick!=null){
				onClick(clickPos);
			}
		}
		if(Input.GetMouseButton(0)){
			currentPos = GetWorldPositionOnPlane(Input.mousePosition,0);
			if(onHold!=null){
				onHold(currentPos);
			}
		}

		if(Input.GetMouseButtonUp(0)){
			Vector2 v = currentPos - clickPos;
			angle = Mathf.Atan2(1 - v.x, v.y) * Mathf.Rad2Deg;
			if(onLift != null){
				onLift(v);
			}
			
		}


	}

	Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
		Ray ray = Camera.main.ScreenPointToRay(screenPosition);
		Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
		float distance;
		xy.Raycast(ray, out distance);
		return ray.GetPoint(distance);
 	}

	
}
