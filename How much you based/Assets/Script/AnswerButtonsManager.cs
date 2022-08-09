using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButtonsManager : MonoBehaviour
{
    [SerializeField] private AnswerButton[] _answerButtons = new AnswerButton[4];
    [SerializeField] private Sprite _defaultAnswerSprite;
    [SerializeField] private Sprite _correctAnswerSprite;

    public void SetButtonState(bool state)
    {
        for (int i = 0; i < _answerButtons.Length; i++)
        {
            _answerButtons[i].SetState(state);
        }
    }

    public void SetDefaultButtonSprites()
    {
        for (int i = 0; i < _answerButtons.Length; i++)
        {
            _answerButtons[i].SetSpriteButtonImage(_defaultAnswerSprite);
        }
    }


    public void SetButtonText(QuestionSO questionSO)
    {
        for (int i = 0; i < _answerButtons.Length; i++)
        {
            _answerButtons[i].SetButtonText(questionSO.GetAnswer(i));
        }
    }

  
    public void SetCorrectAnswerSprit(int indx)
    {
        _answerButtons[indx].SetSpriteButtonImage(_correctAnswerSprite);
    }

    public AnswerButton GetAnswerButton(int indx)
    {
        return _answerButtons[indx];
    }

    public int GetSizeAnswerButtons()
    {
        return _answerButtons.Length;
    }
}
