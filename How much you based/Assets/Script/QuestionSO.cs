using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] private string _question = "Enter new question text here";
    [SerializeField] Sprite _questionSprite;
    [SerializeField] private string[] _answers = new string[4];
    [Range(0, 3)]
    [SerializeField] private int _correctAnswerIndex;

    public string GetQuestion()
    {
        return _question;
    }

    public Sprite GetQuestionSprite()
    {
        return _questionSprite;
    }

    public string GetAnswer(int indxAnswer)
    {
        return _answers[indxAnswer];
    }

    public int Get—orrectAnswerIndex()
    {
        return _correctAnswerIndex;
    }

}
