using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe {
	Vector3 clickPos;
	Vector3 currentPos;
	public float angle;
	
	void Hold(){
		if(Input.GetMouseButtonDown(0)){
			clickPos = Input.mousePosition;
		}
		if(Input.GetMouseButton(0)){
			currentPos =  Input.mousePosition;
		}

		if(Input.GetMouseButtonUp(0)){
			Vector2 v = currentPos - clickPos;
			angle = Mathf.Atan2(1 - v.x, v.y) * Mathf.Rad2Deg;
			Debug.Log(angle );
			
		}

	}

	
}
