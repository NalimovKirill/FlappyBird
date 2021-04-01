using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameOverScreen : Screen
{
    [SerializeField] private Bird _bird;
   public event UnityAction RestartButtonClick;
    [SerializeField] private TMP_Text _highScore;
   protected override void OnButtonClick()
   {
      RestartButtonClick?.Invoke();
   }

   public override void Open()
   {
      CanvasGroup.alpha = 1;
      Button.interactable = true;  
   }

   public override void Close()
   {
      CanvasGroup.alpha = 0;
      Button.interactable = false;
   }
    private void OnEnable()
    {
        _bird.HighScore += OnHighScore;
    }
    private void OnDisable()
    {
        _bird.HighScore -= OnHighScore;
    }

    public void OnHighScore(int highScore)
    {
        _highScore.text = highScore.ToString();
    }
}
