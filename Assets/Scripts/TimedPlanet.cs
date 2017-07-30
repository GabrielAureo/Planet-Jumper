using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPlanet : Planet{
	public float timer;

	// Use this for initialization
	new void Start () {
		base.Start();
		gameObject.tag = "Planet";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player"){
			StartCoroutine(Countdown());
		}
	}

	IEnumerator Countdown(){
		yield return new WaitForSeconds(timer);
		print("WaitAndPrint " + Time.time);
		Explode();
	}

	void Explode(){
		Debug.Log("Boooooooom");
	}
}
