using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour {
	Transform player;
	LineRenderer line;
	public float zPos = -10;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
		line.SetPosition(0,Vector3.forward * zPos);
		line.SetPosition(1,Vector3.forward * zPos);
		line.startWidth = .5f;
		line.endWidth = 0f;
		line.numCapVertices = 0;
	}
	
	void setLineStart(Vector2 start){
		Vector3 start_ = new Vector3(player.position.x,player.position.y,zPos);
		line.SetPosition(0,start_);
		line.SetPosition(1,start_);
		line.numCapVertices = 1;
	}

	void moveLineEnd(Vector2 end){
		Vector3 start_ = new Vector3(player.position.x,player.position.y,zPos);
		line.SetPosition(0,start_);
		Vector3 end_ = new Vector3(end.x,end.y,zPos);
		line.SetPosition(1, end_);
	}

	void endLine(Vector2 end){
		line.SetPosition(0,Vector3.forward * zPos);
		line.SetPosition(1,Vector3.forward * zPos);
		line.numCapVertices = 0;
	}

	void OnDestroy()
	{
		Swipe.onClick -= setLineStart;
		Swipe.onHold -= moveLineEnd;
		Swipe.onLift -= endLine;
	}
}
