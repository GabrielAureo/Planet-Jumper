using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI multiplierText;
	public int score;

	public int multiplier;


	// Use this for initialization
	void Start () {
		multiplier = 1;
		multiplierText.text = concatenateMultiplier(multiplier);
		score =0;
		scoreText.text = score.ToString();
		PlayerCollision.onPlatformHit +=  hitPlatform; 
		BoundCollliders.onGameOver += resetPoints;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void hitPlatform(GameObject platform){
		int points = platform.GetComponent<Platform>().points;

		if(platform.GetComponent<Enemy>() != null){
			increaseMultiplier();
		}else{
			resetMultiplier();
		}

		addPoints(points);
	}

	void addPoints(int points){
		score += points*multiplier;
		scoreText.text = score.ToString();
	}

	void increaseMultiplier(){
		if(multiplier < 10){
			multiplier++;
			multiplierText.text = concatenateMultiplier(multiplier);
		}
	}

	void resetPoints(){
		score = 0;
		scoreText.text = score.ToString();
	}

	void resetMultiplier(){
		multiplier = 1;
		multiplierText.text = concatenateMultiplier(multiplier);
	}

	string concatenateMultiplier(int value){
		return value+"x";
	}

	

}
