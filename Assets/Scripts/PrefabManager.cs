using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour {

	public List<ObstacleEntry> obstacles;
	public List<EnemyEntry> enemies;
	public List<PlanetEntry> planets;

	public static GameObject[] obstaclesList;
	public static GameObject[] enemiesList;
	public static GameObject[] planetsList;
	public static GameObject[] platformList;

    void Awake(){
		obstaclesList = new GameObject[obstacles.Count];
		for (int i =0; i < obstacles.Count; i++){
			obstaclesList[(int)obstacles[i].key] =  obstacles[i].value;
		}
		enemiesList = new GameObject[enemies.Count];
		for (int i =0; i < enemies.Count; i++){
			enemiesList[(int)enemies[i].key] = enemies[i].value;
		}
		planetsList = new GameObject[planets.Count];
		for (int i =0; i < planets.Count; i++){
			planetsList[(int)planets[i].key] = planets[i].value;
		}
		
	}
}
