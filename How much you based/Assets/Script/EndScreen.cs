using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _finalScoreText;
    private ScoreKeeper _scoreKeeper;

    private void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void OnEnable()
    {
        ShowFinalScore();
    }

    private void ShowFinalScore()
    {
        _finalScoreText.text = "You base a " + _scoreKeeper.CalculateScore().ToString() + " %";
    }

}
