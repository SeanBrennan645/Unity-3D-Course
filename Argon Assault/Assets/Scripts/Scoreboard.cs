using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    int score;
    TMP_Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Score: 0";
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = $"Score: {score.ToString()}";
    }
}
