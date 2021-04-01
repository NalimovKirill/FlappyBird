using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _highScore;

    private void Start()
    {
       // _highScore.text = _bird._highScore.ToString();
    }
    private void OnEnable()
    {
        _bird.HighScore += OnHighScore;
        _bird.ScoreChanged += OnScoreChanged;
    }
    private void OnDisable()
    {
        _bird.ScoreChanged -= OnScoreChanged;
        _bird.HighScore -= OnHighScore;

    }
    public void OnScoreChanged(int score)
    {
        _score.text = score.ToString();
    }
    public void OnHighScore(int highScore)
    {
        _highScore.text = highScore.ToString();
    }
}
