using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
	Rigidbody2D rb;
    public float force;

    public Platform platform;

    Vector2 initial;

	// Use this for initialization
	void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Swipe.onLift += Throw;
        PlayerCollision.onPlatformHit += Collided;
        Swipe.onClick += startRotation;
    }
    void Update(){


    }

    void Throw (Vector2 angle){
        Debug.Log(angle);
        Swipe.onHold -= Rotate;
        rb.velocity = Vector3.zero;
        rb.AddForce((angle - (Vector2)transform.position) * force);
	}

    void startRotation(Vector2 initial_){
        initial = initial_;
    }

    void Rotate(Vector2 angle){
        if(platform!= null){
            //transform.position = (Vector2)platform.transform.position + ((angle - initial).normalized * platform.radius);
            transform.position = platform.transform.position + ((Vector3)angle-platform.transform.position).normalized * platform.radius;
        }
        
    }

    void Collided(GameObject other){
        rb.velocity = Vector2.zero;
        if((platform = other.GetComponent<Platform>()) != null){
            transform.position = platform.transform.position + (transform.position - platform.transform.position).normalized * platform.radius;
        }
        if(other.tag == "Planet"){
            Swipe.onHold += Rotate;
        }
    }

    
}
