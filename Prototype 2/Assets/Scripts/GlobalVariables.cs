using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour {

    private int playerLives = 3;
    private int playerScore = 0;


    void Start() {
    }

    public int GetLives() {
        return playerLives;
    }

    public int GetScore() {
        return playerScore;
    }

    public void SubtractALive(int damage) {
        playerLives -= damage;
        Debug.Log("Lives:" + playerLives);
        if (playerLives <= 0) {
            Debug.Log("Game Over!");
        }
    }

}
