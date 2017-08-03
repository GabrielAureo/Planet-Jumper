using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour {
	public static Vector2 center;

	public float[] _platformRadius = new float[2];
	public float[] _obstacleRadius = new float[2];
	public float[] _freeZoneRadius = new float[2];
	public static float[] platformRadius;
	public static float[] obstacleRadius;
	public static float[] freeZoneRadius;

	// Use this for initialization
	void Awake () {
		center = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth,Camera.main.pixelHeight)/2);
		platformRadius = _platformRadius;
		obstacleRadius = _obstacleRadius;
		freeZoneRadius = _freeZoneRadius;
		
	}

	void Start(){
		PlayerCollision.onPlatformHit += updateCenter;

		
	}

	void updateCenter(GameObject hit){
		center = hit.transform.position;
	}
}
