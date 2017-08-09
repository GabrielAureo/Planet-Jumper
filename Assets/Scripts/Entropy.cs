using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entropy: Obstacle{

    override protected void onHit(Collider2D etc){
        
        if(StageGenerator.platformList.Count <= 1){
            return;
        }

        int toDestroy = Random.Range(1,StageGenerator.platformList.Count - 1);

        for(int i =0; i < toDestroy; i++){
            GameObject todestroy = StageGenerator.platformList[Random.Range(0,StageGenerator.platformList.Count)];
            StageGenerator.platformList.Remove(todestroy);
            GameObject.Destroy(todestroy);
        }

        Destroy(gameObject);
    }
}