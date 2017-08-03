using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum ObstacleEnum{
    BlackHole, WormHole, Entropy
}

public class ObstacleGenerator : ElementGenerator<ObstacleEnum,GameObject>{

    List<GameObject> obstacles = new List<GameObject>();

    public ObstacleGenerator(Dictionary<ObstacleEnum,GameObject> prefabs, float minBound, float maxBound) : base(prefabs, minBound, maxBound){
        foreach(GameObject element in prefabs.Values){
            obstacles.Add(element);
        }
    }

    override public List<GameObject> Spawn(List<Vector2> positions){
        foreach(Vector2 pos in positions){
				GameObject obstacle = obstacles[Random.Range(0,obstacles.Count)];
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