using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour {

	//public List<PrefabEntry> obstaclesEntries = new List<PrefabEntry>();
	public Dictionary<string,GameObject> obstacles;
	//public List<PrefabEntry> enemiesEntries = new List<PrefabEntry>();
	public Dictionary<string,GameObject> enemies;
	//public List<PrefabEntry> planetsEntries = new List<PrefabEntry>();
	public Dictionary<string,GameObject> planets;


	public void Delete(Dictionary<string,GameObject> dict, string key){
		dict.Remove(key);
	}

	public void Add(Dictionary<string,GameObject> dict, string key, GameObject value){
		dict.Add(key, value);
	}
}
