using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : Platform {

	public float alpha = .5f;

	new void Start()
	{
		base.Start();

		gameObject.tag = "Planet";

	}

	void OnTriggerExit2D(Collider2D other)
	{	
		if(other.tag == "Player"){
			gameObject.GetComponent<Collider2D>().enabled = false;
			Color color = gameObject.GetComponent<SpriteRenderer>().color;
			color = new Color(color.r,color.g,color.b,alpha);
			gameObject.GetComponent<SpriteRenderer>().color = color;
		}
	}
}
