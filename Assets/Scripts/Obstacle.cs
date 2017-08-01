using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle: MonoBehaviour{

    void Start(){
        gameObject.tag = "Obstacle";
    }


    abstract protected void onHit(Collider2D other);

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            onHit(other);
        }
    }
    
}