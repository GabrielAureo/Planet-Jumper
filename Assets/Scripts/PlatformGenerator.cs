using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {
	List<GameObject> platforms;
	float radius_x;
	float radius_y;
	public GameObject[] platformPrefabs;

	// Use this for initialization
	void Start () {
		platforms = new List<GameObject>();
		Vector2 edgeVector = Camera.main.ScreenToWorldPoint(Vector2.zero);
		radius_x = edgeVector.x;
		radius_y = edgeVector.y;
		
		PlayerCollision.onPlatformHit += getPlanetHit;

		generate(Vector2.zero);
	}
	
	// Update is called once per frame
	public void getPlanetHit(GameObject hit){
		if(platforms.Contains(hit)){
			deletePlanets(hit);
			generate(hit.transform.position);
		}
	}
	public void generate(Vector2 center){
		List<Vector2> planetsPos = randomPoints();
		foreach(Vector2 planetPos in planetsPos){
				GameObject platform = platformPrefabs[Random.Range(0,platformPrefabs.Length)];
				GameObject p = (GameObject) Instantiate(platform, planetPos + center, new Quaternion(0,0,0,0));
				platforms.Add(p);
				
		}
	}

	List<Vector2> randomPoints(){

		List<Vector2> planetPos = new List<Vector2>();
		int planetsCount = Random.Range(2,6);
		float partAngles = ((2*Mathf.PI) / (planetsCount));
		float totalRotation = Random.value * Mathf.PI;

		for(int i = 0; i < planetsCount; i++){
			float rotation = Random.Range(-20 * Mathf.Deg2Rad, 20 * Mathf.Deg2Rad);
			float angle = partAngles * i;
			float x = Mathf.Cos(angle + rotation + totalRotation)*(radius_x);
			float y = Mathf.Sin(angle + rotation + totalRotation)*(radius_y);
			Vector2 pos = new Vector2(x,y);
			pos *= Random.Range(.8f,1.0f);
			planetPos.Add(pos);
		}
		return planetPos;
	}

	void deletePlanets(GameObject hit){
		foreach(GameObject planet in platforms){
			if(planet == hit){
				continue;
			}
			Destroy(planet);
		}
		platforms.Clear();
		platforms.Add(hit);
	}
}
