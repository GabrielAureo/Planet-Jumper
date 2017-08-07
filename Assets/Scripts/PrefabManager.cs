using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour {

	public List<ObstacleEntry> obstacles;
	public List<EnemyEntry> enemies;
	public List<PlanetEntry> planets;

	public static List<GameObject> obstaclesList;
	public static List<GameObject> enemiesList;
	public static List<GameObject> planetsList;

    void Awake(){
		Debug.Log(obstacles.Count);
		obstaclesList = new List<GameObject>(new GameObject[obstacles.Count]);
		Debug.Log(obstaclesList.Count);
		for (int i =0; i < obstacles.Count; i++){
			Debug.Log("i" + i + (int)(obstacles[i].key));
			obstaclesList.Insert((int)(obstacles[i].key), obstacles[i].value);
		}
		enemiesList = new List<GameObject>(new GameObject[enemies.Count]);
		for (int i =0; i < enemies.Count; i++){
			enemiesList.Insert((int)enemies[i].key, enemies[i].value);
		}
		planetsList = new List<GameObject>(new GameObject[planets.Count]);
		for (int i =0; i < planets.Count; i++){
			planetsList.Insert((int)planets[i].key, planets[i].value);
		}
		
	}

	void Start(){
		printListinha(obstaclesList);
		printListinha(enemiesList);
		printListinha(planetsList);
	}

	void printListinha(List<GameObject> list){
		for(int i =0; i < list.Count; i++){
			Debug.Log(i.ToString() + list[i]);
		}
	}
}
