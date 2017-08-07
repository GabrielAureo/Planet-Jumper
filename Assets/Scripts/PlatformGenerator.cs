using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformGenerator : ElementGenerator{
    List<GameObject> enemies = new List<GameObject>();
    List<GameObject> platforms = new List<GameObject>();
    

    public PlatformGenerator(float minBound, float maxBound) : base(minBound,maxBound){
        enemies.AddRange(PrefabManager.enemiesList);
        platforms.AddRange(PrefabManager.planetsList);
        platforms.AddRange(PrefabManager.enemiesList);        
        
    }
    override public List<GameObject> Spawn(List<Vector2> positions){
        GameObject chosenEnemy = enemies[Random.Range(0,enemies.Count)];
        Vector2 chosenPosition = positions[Random.Range(0,positions.Count)];
        positions.Remove(chosenPosition);
        GameObject e = GameObject.Instantiate(chosenEnemy,chosenPosition, new Quaternion(0,0,0,0));
        elements.Add(e);

        foreach(Vector2 pos in positions){
				GameObject platform = platforms[Random.Range(0,platforms.Count)];
				GameObject p = GameObject.Instantiate(platform, pos, new Quaternion(0,0,0,0));
				elements.Add(p);
		}

        return elements;
    }
    

    override public void Delete(GameObject hit){
        foreach(GameObject element in elements){
			if(element == hit){
				continue;
			}
			GameObject.Destroy(element);
		}
		elements.Clear();
		elements.Add(hit);

    }
}