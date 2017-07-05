using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour {

	LineRenderer line;

	// Use this for initialization
	void Start () {
		line = gameObject.GetComponent<LineRenderer>();
		SetupLine();
		Swipe.onClick += setLineStart;
		Swipe.onHold += moveLineEnd;
		Swipe.onLift += endLine;
	}

	void Update(){
		
	}

	void SetupLine(){
		line.positionCount = 2;
		line.SetPosition(0,Vector3.zero);
		line.SetPosition(1,Vector3.zero);
		line.startWidth = .5f;
		line.endWidth = 0f;
		line.numCapVertices = 0;
	}
	
	void setLineStart(Vector2 start){
		line.SetPosition(0,start);
		line.SetPosition(1,start);
		line.numCapVertices = 1;
	}

	void moveLineEnd(Vector2 end){
		line.SetPosition(1,end);
	}

	void endLine(Vector2 end){
		line.SetPosition(0,Vector3.zero);
		line.SetPosition(1,Vector3.zero);
		line.numCapVertices = 0;
	}
}
