using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

static class Constants
{
    public const int spriteHalf = 64;
    public const float maxradius = 3;

}

public class PlanetsGenerator : MonoBehaviour {
	//List<Vector2> planetsPos;
	List<GameObject> planets;
	float radius_x;
	float radius_y;
	public GameObject platform;
	//Vector3 plane;

	// Use this for initialization
	void Start () {
		//planetsPos = new List<Vector2>();
		planets = new List<GameObject>();
		Vector2 edgeVector = Camera.main.ScreenToWorldPoint(Vector2.one);
		radius_x = edgeVector.x;
		radius_y = edgeVector.y;
		
		PlayerCollision.onHit += getPlanetHit;

		generate(Vector2.zero);
	}
	
	// Update is called once per frame
	public void getPlanetHit(GameObject hit){

		deletePlanets(hit);
		generate(hit.transform.position);
	}
	public void generate(Vector2 center){
		List<Vector2> planetsPos = randomPoints();
		foreach(Vector2 planetPos in planetsPos){
				GameObject p = (GameObject) Instantiate(platform, planetPos + center, new Quaternion(0,0,0,0));
				planets.Add(p);
				
		}
	}

	List<Vector2> randomPoints(){

		List<Vector2> planetPos = new List<Vector2>();
		int planetsCount = Random.Range(1,5);
		planetsCount = 5;
		float partAngles = ((2*Mathf.PI) / (planetsCount));

		for(int i = 0; i < planetsCount; i++){
			float rotation = Random.Range(-10 * Mathf.Deg2Rad, 10 * Mathf.Deg2Rad);
			float angle = partAngles * i;
			float x = Mathf.Cos(angle + rotation )*(radius_x);
			float y = Mathf.Sin(angle + rotation)*(radius_y);
			Vector2 pos = new Vector2(x,y);
			pos *= Random.Range(.4f,1.0f);
			planetPos.Add(pos);
		}
		return planetPos;
	}

	void deletePlanets(GameObject hit){
		foreach(GameObject planet in planets){
			if(planet == hit){
				continue;
			}
			Destroy(planet);
		}
		planets.Clear();
		planets.Add(hit);
	}
}
