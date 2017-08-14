using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI multiplierText;

	public int score;

	public delegate void ScoreWatcher(int value);
	public static ScoreWatcher onPoint;
	public static ScoreWatcher onCombo;
	public static ScoreWatcher onReset;

	int multiplier;
	public int maxMultiplier;
	public int multiplierStep;


	// Use this for initialization
	void Start () {
		multiplier = 1;
		multiplierText.text = concatenateMultiplier(multiplier);
		score =0;
		scoreText.text = score.ToString();
		PlayerCollision.onPlatformHit +=  hitPlatform; 
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

		if(onPoint != null) onPoint(score);
	}

	void increaseMultiplier(){
		if(multiplier < maxMultiplier){
			multiplier += multiplierStep;
			multiplierText.text = concatenateMultiplier(multiplier);
			if(onCombo != null) onCombo(multiplier);

		}
	}

	void resetPoints(){
		score = 0;
		scoreText.text = score.ToString();
	}

	void resetMultiplier(){
		multiplier = 1;
		multiplierText.text = concatenateMultiplier(multiplier);
		if(onReset != null) onReset(multiplier);
	}

	string concatenateMultiplier(int value){
		return value+"x";
	}

	void OnDestroy(){
		onPoint = null;
		onCombo = null;
	}

	

}
