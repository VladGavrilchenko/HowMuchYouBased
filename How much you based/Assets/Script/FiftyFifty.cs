using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiftyFifty : MonoBehaviour
{
    [SerializeField] private Sprite _fiftyFiftySprite;
    [SerializeField] private Button _button;
    private AnswerButtonsManager _answerButtonsManager;
    private IQuiz _iquiz;
    private bool _isUse;

    private void Start()
    {
        _answerButtonsManager = FindObjectOfType<AnswerButtonsManager>();
        Quiz quiz = FindObjectOfType<Quiz>();
        quiz.AnswerEvent.AddListener(SetInteractable);
        _iquiz = FindObjectOfType<Quiz>().GetComponent<IQuiz>();
    }

    public void GetFiftyFifty()
    {
        _button.interactable = false;
        int currentAnswerIndx = _iquiz.GetCurrentQustion().Get—orrectAnswerIndex();
        int wrongAnswerIndx;
        _isUse = true;
        while (true)
        {
            wrongAnswerIndx = Random.Range(0, _answerButtonsManager.GetSizeAnswerButtons());

            if (wrongAnswerIndx != currentAnswerIndx)
            {
                break;
            }
        }
        _answerButtonsManager.GetAnswerButton(currentAnswerIndx).SetSpriteButtonImage(_fiftyFiftySprite);
        _answerButtonsManager.GetAnswerButton(wrongAnswerIndx).SetSpriteButtonImage(_fiftyFiftySprite);
    }

    private void SetInteractable(bool isInteractab)
    {
        if (_isUse)
        {
            Quiz quiz = FindObjectOfType<Quiz>();
            quiz.AnswerEvent.RemoveListener(SetInteractable);
        }
        else
        {
            _button.interactable = isInteractab;
        }
    }
}
