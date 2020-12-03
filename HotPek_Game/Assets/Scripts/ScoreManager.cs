using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instence;
    public int score;
    public int FruitScore = 10;
    public Text scoretext, TotalScore;
    private void Awake()
    {
        instence = this;
    }


    public void addScore()
    {
        score = score + FruitScore;
        scoretext.text = score.ToString();
        TotalScore.text = score.ToString();
    }

    public void ResetScore() {
        score = 0;
    }
}
