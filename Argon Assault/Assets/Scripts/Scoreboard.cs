using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    int score;

    public void UpdateScore(int value)
    {
        score += value;
        Debug.Log($"Current Score: {score}");
    }
}
