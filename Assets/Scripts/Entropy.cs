using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entropy: Obstacle{

    override protected void onHit(Collider2D etc){
        
        List<GameObject> platforms = StageGenerator.platformList;
        if(platforms.Count <= 1){
            return;
        }

        int toDestroy = Random.Range(1,platforms.Count - 1);

        for(int i =0; i < toDestroy; i++){
            GameObject.Destroy(platforms[Random.Range(0,platforms.Count)]);
            platforms.RemoveAt(i);
        }

        Destroy(gameObject);
    }
}