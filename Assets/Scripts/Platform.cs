using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platform: MonoBehaviour {

	public float radius;

	public float points;

	protected void Start(){
		radius = Random.Range(0.5f,0.75f);
		gameObject.transform.localScale *= radius *2;
	}


}
