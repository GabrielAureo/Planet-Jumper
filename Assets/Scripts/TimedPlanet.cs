using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPlanet : Planet{
	public float timer;
	public float maxPulses;
	int pulses;
	float tick;
	public ParticleSystem emitter;
	public ParticleSystem explosion;
	Animator anim;

	void Awake(){

		anim = GetComponent<Animator>();
	}
	// Use this for initialization
	new void Start () {
		pulses = 0;
		tick = timer/maxPulses;
		base.Start();
		gameObject.tag = "Planet";	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player"){
			InvokeRepeating("Countdown", 0.0f, tick);
		}
	}

	void Countdown(){
		if(pulses >= maxPulses){
			CancelInvoke();
			Explode();
			return;
		}
		emitter.Emit(3 + (pulses * 2));
		pulses++;
		
	}

	void Explode(){
		explosion.Play();
		Debug.Log("Boooooooom");
	}
}
