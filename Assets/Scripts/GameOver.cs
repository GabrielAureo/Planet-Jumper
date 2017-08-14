using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver: MonoBehaviour{

    public static void ResetGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

}