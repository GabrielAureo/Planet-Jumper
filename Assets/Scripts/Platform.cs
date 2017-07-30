using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platform: MonoBehaviour {

	public float radius;

	public int points;

	protected void Start(){
		float sprite_radius = GetComponent<SpriteRenderer>().sprite.bounds.size.x/2;
		radius = Random.Range(0.5f,0.75f);
		gameObject.transform.localScale *= radius *2;

		radius += sprite_radius;
	}


}
