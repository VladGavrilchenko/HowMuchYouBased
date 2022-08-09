using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

interface IQuiz
{
    QuestionSO GetCurrentQustion();
}

public class Quiz : MonoBehaviour , IQuiz
{
    [SerializeField] private TextMeshProUGUI _questionText;
    [SerializeField] private Image _questionImage;
    private QuestionsManager _questionsManager;
    private QuestionSO _currentQuestion;
    private AnswerButtonsManager _answerButtonsManager;
    private bool _hasAnswered;
    private ScoreKeeper _scoreKeeper;
    private Timer _timer;
    public UnityEvent<bool> AnswerEvent;
    public UnityEvent EndEvent;

    private void Start()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _answerButtonsManager = FindObjectOfType<AnswerButtonsManager>();
        _questionsManager = FindObjectOfType<QuestionsManager>();
        _timer = FindObjectOfType<Timer>();
        _hasAnswered = true;
    }

    private void Update()
    {
        if (_timer.IsLoadNextQustion())
        {
            _hasAnswered = false;
            NextQustion();
            _timer.SetIsLoadNextQustion(false);
        }
        else if (!_hasAnswered && !_timer.IsAnsweringQuestion())
        {
            DisplayAnswer(-1);
            _answerButtonsManager.SetButtonState(false);
        }
    }

    public void OnAnswerSelected(int indx)
    {
        _hasAnswered = true;
        DisplayAnswer(indx);
        _answerButtonsManager.SetButtonState(false);
        _timer.CancelTimer();
    }

    private void DisplayAnswer(int indx)
    {
        if (indx == _currentQuestion.GetÑorrectAnswerIndex())
        {
            _questionText.text = "Correct!";
            _scoreKeeper.AddCountCurrentAnswer();
        }
        else
        {
            int correctAnswerIndex = _currentQuestion.GetÑorrectAnswerIndex();
            _questionText.text = "Sorry, the correct answer was: " + _currentQuestion.GetAnswer(correctAnswerIndex);
        }

    
        _answerButtonsManager.SetCorrectAnswerSprit(_currentQuestion.GetÑorrectAnswerIndex());
        AnswerEvent.Invoke(false);
    }

    private void NextQustion()
    {
        if (_questionsManager.GetCountOfQuestion() > 0)
        {
            SetNextQuestion();
            _answerButtonsManager.SetButtonState(true);
            _answerButtonsManager.SetDefaultButtonSprites();
            _answerButtonsManager.SetButtonText(_currentQuestion);
            AnswerEvent.Invoke(true);
            _scoreKeeper.AddToCompleted();
        }

        else if (_questionsManager.IsQustionsEmpty())
        {
            _timer.Stop();
            EndEvent.Invoke();
        }

    }

    private void SetNextQuestion() 
    {
        _currentQuestion = _questionsManager.GetRandomQuestion();
        DisplayQuestion();
    }

    private void DisplayQuestion()
    {
        _questionText.text = _currentQuestion.GetQuestion();
        _questionImage.sprite = _currentQuestion.GetQuestionSprite();
    }

    public QuestionSO GetCurrentQustion()
    {
        return _currentQuestion;
    }

}
