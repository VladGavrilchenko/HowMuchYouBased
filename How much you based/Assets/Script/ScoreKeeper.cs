using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _completedText;
    private int _countOfCompleted;
    private int _maxCountQuestion;
    private int _countOfCurrentAnswer;

    private void Awake()
    {
        IQuestionsManager iQuestionsManager = FindObjectOfType<QuestionsManager>().GetComponent<IQuestionsManager>();
        _maxCountQuestion = iQuestionsManager.GetCountOfQuestion();
        UpdateCompletedText();
    }

    private void UpdateCompletedText()
    {
        _completedText.text = "Qustion: "+ _countOfCompleted + "/" + _maxCountQuestion + "\nScore: " + CalculateScore().ToString() + "%";
    }

    public void AddToCompleted()
    {
        _countOfCompleted++;
        UpdateCompletedText();
    }

    public void AddCountCurrentAnswer()
    {
        _countOfCurrentAnswer++;
    }

    public int CalculateScore()
    {
        return Mathf.RoundToInt(_countOfCurrentAnswer / (float)_maxCountQuestion * 100);
    }

}
