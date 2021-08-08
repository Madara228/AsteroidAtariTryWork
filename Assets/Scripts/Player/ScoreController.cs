using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;
    public Text scoreText;
    int scoreValue = 0;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void AddScore(int score)
    {
        scoreValue += score;
        scoreText.text = scoreValue.ToString();
    }
}
