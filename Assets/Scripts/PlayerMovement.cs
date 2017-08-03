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
        Swipe.onLift += Launch;
        PlayerCollision.onPlatformHit += Collided;
        Swipe.onClick += startRotation;
    }
    void Update(){


    }

    public void Launch(Vector2 angle){
        Vector2 direction = angle - (Vector2)transform.position;
        Throw(direction);

    }

    public void changeDirection(Vector2 angle){
        Vector2 direction = angle.normalized * (rb.velocity.magnitude);
        rb.velocity = direction;
    }

    public void Throw (Vector2 direction){
        Swipe.onHold -= Rotate;
        rb.velocity = Vector2.zero;
        if(direction.magnitude < 1)
            direction = direction.normalized;
        rb.AddForce(direction * force);

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
