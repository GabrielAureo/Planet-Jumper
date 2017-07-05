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
			clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Debug.Log(clickPos);
			if(onClick!=null){
				onClick(clickPos);
			}
		}
		if(Input.GetMouseButton(0)){
			currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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

	
}
