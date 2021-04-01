using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private int _score;
    private int _highScore;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;
    public event UnityAction<int> HighScore;

    private void Start()
    {
        _mover = GetComponent<BirdMover>();
    }

    public void IncreaseScore()
    {
        _score++;

        if (_score > _highScore)
        {
            _highScore = _score;
            HighScore?.Invoke(_highScore);
        }

        ScoreChanged?.Invoke(_score);
    }

    public void ResetPlayer()
    {
        _score = 0;
        _mover.ResetBird();
        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        GameOver?.Invoke();
    }
}
