using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image _timerImage;
    [SerializeField] private float _timeToCompleteQuestion = 30f;
    [SerializeField] private float _timeToShowCorrectAnswer = 10f;
    private float _fillFraction;
    private float _timerValue;
    private bool _isGo;
    private bool _isLoadNextQustion;
    private bool _isAnsweringQuestion;

    private void Start()
    {
        _isGo = true;
    }

    private void Update()
    {
        if(_isGo)
        {
            UpdateTimer();
        }
    }
    
    public void SetIsLoadNextQustion(bool isLoadNextQustion)
    {
        _isLoadNextQustion = isLoadNextQustion;
    }

    public bool IsLoadNextQustion()
    {
        return _isLoadNextQustion;
    }

    public void SetIsAnsweringQuestion(bool isAnsweringQuestion)
    {
        _isAnsweringQuestion = isAnsweringQuestion;
    }

    public bool IsAnsweringQuestion()
    {
        return _isAnsweringQuestion;
    }

    public void Stop()
    {
        _isGo = false;
    }

    public void CancelTimer()
    {
        _timerValue = 0;
    }

    private void UpdateTimer()
    {
        _timerValue -= Time.deltaTime;

        if (_isAnsweringQuestion)
        {
            if (_timerValue > 0)
            {
                _fillFraction = _timerValue / _timeToCompleteQuestion;
            }
            else
            {
                _isAnsweringQuestion = false;
                _timerValue = _timeToShowCorrectAnswer;
            }
        }
        else
        {
            if(_timerValue > 0)
            {
                _fillFraction = _timerValue / _timeToShowCorrectAnswer;
            }
            else
            {
                _isAnsweringQuestion = true;
                _timerValue = _timeToCompleteQuestion;
                _isLoadNextQustion = true;
            }
        }

        _timerImage.fillAmount = _fillFraction;
    }

}
