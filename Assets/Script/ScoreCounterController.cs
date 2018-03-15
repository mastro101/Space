using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScoreCounterController : MonoBehaviour
{
    public Text ScoreText;
    public PlayerData CurrentPlayer;

    private void OnEnable()
    {
        EventManager.OnScoreUpdated += UpdateScore;
    }

    private void UpdateScore(PlayerData player)
    {
        if (player == CurrentPlayer)
        ScoreText.text = "Score:" + player.Score.ToString();
    }

    private void OnDisable()
    {
        EventManager.OnScoreUpdated -= UpdateScore;
    }
}
