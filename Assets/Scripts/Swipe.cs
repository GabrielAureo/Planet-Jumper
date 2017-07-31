﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe: MonoBehaviour {
	Vector2 clickPos;
	Vector2 currentPos;
	[SerializeField]
	float angle;

	public delegate void mouseHandler(Vector2 pos);
	public static event mouseHandler onClick;
	public static event mouseHandler onHold;
	public static event mouseHandler onLift;

	bool canSwipe;


	void Start(){
		CameraController.finishedMoving += canSwipeAgain;
		canSwipe = true;
	}

	
	void Update(){
		if(canSwipe){
			if(Input.GetMouseButtonDown(0)){
				clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				Debug.Log(clickPos);
				if(onClick!=null){
					onClick(clickPos);
				}
			}
			if(Input.GetMouseButton(0)){
				currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				Vector2 v = clickPos - currentPos;
				if(onHold!=null){
					onHold(currentPos);
				}
			}

			if(Input.GetMouseButtonUp(0)){
				Vector2 v = currentPos - clickPos;
				//angle = Mathf.Atan2(1 - v.x, v.y) * Mathf.Rad2Deg;
				if(onLift != null){
					onLift(currentPos);
				}
				if(v.magnitude != 0.0f)
					canSwipe = false;
				
			}
		}


	}

	void canSwipeAgain(){
		canSwipe = true;
	}

	

	 void OnDestroy()
	 {		
		onClick = null;
		onHold = null;
		onLift = null;
	 }

	
}
