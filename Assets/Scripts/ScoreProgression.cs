using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ProgressionType{
	Combo, Score
}
public class ScoreProgression : MonoBehaviour {

	public static int scoreLevel = 0; 
	public static int comboLevel = 0;

	public DifficultyLevels scoreLevels;
	public DifficultyLevels comboLevels;	

	void Awake()
	{
		scoreLevel = 0;
		comboLevel = 0;

		Score.onCombo += updatedifficultyCombo;
		Score.onPoint += updatedifficultyScore;
		Score.onReset += resetDifficultyCombo;
	}

	void updatedifficultyScore(int score){
		if(scoreLevel < comboLevels.list.Length -1 && score > scoreLevels.list[scoreLevel]){
			scoreLevel++;
		}
	}

	void updatedifficultyCombo(int multiplier){
		if(comboLevel < comboLevels.list.Length - 1 && multiplier > comboLevels.list[comboLevel]){
			comboLevel++;
		}
	}

	void resetDifficultyCombo(int etc){
		comboLevel = 0;
		
	}

}
