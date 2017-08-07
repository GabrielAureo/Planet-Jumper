using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageGenerator : MonoBehaviour {

	PlatformGenerator platformGenerator;
	ObstacleGenerator obstacleGenerator;

	List<GameObject> platformList;
	List<GameObject> obstacleList;

	

	List<ObstacleEnum> enums = new List<ObstacleEnum>(){ObstacleEnum.WormHole, ObstacleEnum.Entropy};
	// Use this for initialization
	void Start () {
		platformGenerator = new PlatformGenerator(ScreenManager.platformRadius[0],ScreenManager.platformRadius[1]);

		
		obstacleGenerator = new ObstacleGenerator(ScreenManager.obstacleRadius[0],ScreenManager.obstacleRadius[1]);

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
