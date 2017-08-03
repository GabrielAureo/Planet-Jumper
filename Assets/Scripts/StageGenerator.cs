using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageGenerator : MonoBehaviour {
	public List<GameObject> enemiesPrefabs;
	public List<GameObject> planetsPrefabs;
	Dictionary<PlatformsEnum, List<GameObject>> PlatformDictionary;
	
	public static List<GameObject> platformList;
	public static List<GameObject> obstacleList;

	public List<GameObject> obstaclesPrefabs;
	Dictionary<ObstacleEnum, GameObject> ObstacleDictionary;

	PlatformGenerator platformGenerator;
	ObstacleGenerator obstacleGenerator;

	

	List<ObstacleEnum> enums = new List<ObstacleEnum>(){ObstacleEnum.WormHole, ObstacleEnum.Entropy};
	// Use this for initialization
	void Start () {

		PlatformDictionary = new Dictionary<PlatformsEnum, List<GameObject>>(){
			{PlatformsEnum.Enemy, enemiesPrefabs},
			{PlatformsEnum.Planet, planetsPrefabs},
		};
		platformGenerator = new PlatformGenerator(PlatformDictionary,ScreenManager.platformRadius[0],ScreenManager.platformRadius[1]);
	

		ObstacleDictionary = new Dictionary<ObstacleEnum,GameObject>();
		//Temporário

		for(int i = 0; i < obstaclesPrefabs.Count; i++){
			ObstacleDictionary.Add(enums[i],obstaclesPrefabs[i]);
		}
		
		obstacleGenerator = new ObstacleGenerator(ObstacleDictionary,ScreenManager.obstacleRadius[0],ScreenManager.obstacleRadius[1]);

		PlayerCollision.onPlatformHit += newStage;
		stageLayout(Vector2.zero);
		
	}

	void newStage(GameObject hit){
		platformGenerator.Delete(hit);
		obstacleGenerator.Delete(hit);
		stageLayout(hit.transform.position);
	}

	void stageLayout(Vector2 center){
		List<Vector2> platformPositions, obstaclePositions;
		float platformWorldRotation = Random.value * 2 * Mathf.PI;
		float obstacleWorldRotation = Random.value * 2 * Mathf.PI;
		platformPositions = platformGenerator.posGen.uniformDistance(platformCount(),center,platformWorldRotation);
		obstaclePositions = obstacleGenerator.posGen.uniformDistance(obstacleCount(),center,obstacleWorldRotation);
		platformList = platformGenerator.Spawn(platformPositions);
		obstacleList = obstacleGenerator.Spawn(obstaclePositions);

	}

	int platformCount(){
		return Random.Range(2,6);
	}

	int obstacleCount(){
		return Random.Range(1,3);
	}

	
}
