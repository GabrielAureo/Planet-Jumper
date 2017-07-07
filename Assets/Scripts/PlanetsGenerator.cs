using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlanetsGenerator : MonoBehaviour {
	[SerializeField]
	List<Vector2> planetsPos;
	List<GameObject> planets;
	public float radius;
	public GameObject platform;

	// Use this for initialization
	void Start () {
		planetsPos = new List<Vector2>();
		planets = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update() {
		if(Input.GetKeyDown(KeyCode.A)){
			randomPoints();
			foreach(Vector2 planetPos in planetsPos){
				planets.Add((GameObject) Instantiate(platform, planetPos, new Quaternion(0,0,0,0)));
			}
		}
		
	}

	void randomPoints(){
		List<Vector2> temp = new List<Vector2>();
		int planetsCount = Random.Range(1,5);
		float partAngles = (2*Mathf.PI) / (planetsCount);
		float rotation = Random.value * Mathf.PI;

		deletePlanets();

		for(int i = 0; i < planetsCount; i++){
			float angle = partAngles * i;
			float x = Mathf.Cos(angle + rotation)*radius;
			float y = Mathf.Sin(angle + rotation)*radius;
			Vector2 pos = new Vector2(x,y) + Random.insideUnitCircle;
			temp.Add(pos);
		}
		planetsPos = temp;
	}

	void deletePlanets(){
		foreach(GameObject planet in planets){
			Destroy(planet);
		}
	}

	void OnDrawGizmos()
	{
		
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(Vector3.zero, radius);
	}
}
