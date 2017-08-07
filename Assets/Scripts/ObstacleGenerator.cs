using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObstacleGenerator : ElementGenerator{

    public ObstacleGenerator (float minBound, float maxBound) : base(minBound, maxBound){
    }

    override public List<GameObject> Spawn(List<Vector2> positions){
        foreach(Vector2 pos in positions){
				GameObject obstacle = PrefabManager.obstaclesList[Random.Range(0,PrefabManager.obstaclesList.Length)];
				GameObject p = GameObject.Instantiate(obstacle, pos, new Quaternion(0,0,0,0));
				elements.Add(p);
		}
        return elements;
    }

    override public void Delete(GameObject hit){
        foreach(GameObject element in elements){
            GameObject.Destroy(element);
        }
        elements.Clear();
    }

}