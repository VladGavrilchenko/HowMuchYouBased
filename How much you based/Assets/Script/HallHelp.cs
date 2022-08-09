using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HallHelp : MonoBehaviour 
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _textHallAnswer;
    private IQuiz _iQuiz;
    private bool _isUse;

    private void Start()
    {
        SetAnswerVisibly(false);
        Quiz quiz = FindObjectOfType<Quiz>();
        quiz.AnswerEvent.AddListener(CloseTooltip);
        _iQuiz = FindObjectOfType<Quiz>().GetComponent<IQuiz>();
    }

    public void SetAnswerVisibly(bool isVisily)
    {
        _textHallAnswer.enabled = isVisily;
    }

    public void SeeHallAnswer()
    {
        _button.interactable = false;
        _textHallAnswer.text = "Most people think it a " + _iQuiz.GetCurrentQustion().GetAnswer(_iQuiz.GetCurrentQustion().Get—orrectAnswerIndex());
        _textHallAnswer.enabled = true;
        _isUse = true;
    }

    private void CloseTooltip(bool a)
    {
        if (_isUse)
        {
            SetAnswerVisibly(false);
            Quiz quiz = FindObjectOfType<Quiz>();
            quiz.AnswerEvent.RemoveListener(CloseTooltip);
        }
        else
        {
            _button.interactable = a;
        }
    }
}
