using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageGenerator : MonoBehaviour {
	public List<GameObject> enemiesPrefabs;
	public List<GameObject> planetsPrefabs;

	Dictionary<PlatformsEnum, List<GameObject>> PlatformDictionary;
	

	public GameObject[] obstaclesPrefabs;
	//Dictionary<ObstacleEnum, List<GameObject>> ObstacleDictionary; #TODO

	PlatformGenerator platformGenerator;
	//PositionGenerator obstacleGenerator;

	


	// Use this for initialization
	void Start () {
		PlatformDictionary = new Dictionary<PlatformsEnum, List<GameObject>>(){
			{PlatformsEnum.Enemy, enemiesPrefabs},
			{PlatformsEnum.Planet, planetsPrefabs},
		};
		platformGenerator = new PlatformGenerator(PlatformDictionary,.8f, 1.0f);
		PlayerCollision.onPlatformHit += newStage;
		stageLayout(Vector2.zero);
		
	}

	void newStage(GameObject hit){
		platformGenerator.Delete(hit);
		stageLayout(hit.transform.position);
	}

	void stageLayout(Vector2 center){
		List<Vector2> platformPositions;
		float worldRotation = Random.value * Mathf.PI;
		platformPositions = platformGenerator.posGen.uniformDistance(platformCount(),center);
		platformGenerator.Spawn(platformPositions);

	}

	int platformCount(){
		return Random.Range(2,6);
	}

}
