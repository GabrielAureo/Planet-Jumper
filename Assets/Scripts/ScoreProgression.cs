using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreProgression : MonoBehaviour {

	public static int scoreLevel = 0; 
	public static int comboLevel = 0;
	public static int maxScorelevel;
	public static int maxComboLevel;


	public int[] difficultyScore;
	public int[] difficultyCombo;

	void Awake()
	{
		scoreLevel = 0;
		comboLevel = 0;
		Score.onPoint += updatedifficultyScore;
		Score.onCombo += updatedifficultyCombo;
		Score.onReset += resetDifficultyCombo;
	}

	void updatedifficultyScore(int score){
		if(scoreLevel < difficultyScore.Length -1 && score > difficultyScore[scoreLevel]){
			scoreLevel++;
		}
	}

	void updatedifficultyCombo(int multiplier){
		if(comboLevel < difficultyCombo.Length - 1 && multiplier > difficultyCombo[comboLevel]){
			comboLevel++;
		}
	}

	void resetDifficultyCombo(int etc){
		comboLevel = 0;
	}
}
