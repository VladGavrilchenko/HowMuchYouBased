using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IQuestionsManager
{
    int GetCountOfQuestion();
}

public class QuestionsManager : MonoBehaviour , IQuestionsManager
{
    [SerializeField] private List<QuestionSO> _questions;

    private void RemoveQuestionInList(QuestionSO removeQuestion)
    {
       _questions.Remove(removeQuestion);
    }

    public QuestionSO GetRandomQuestion()
    {
        int index = Random.Range(0, _questions.Count);
        QuestionSO randomQuestion = _questions[index];
        RemoveQuestionInList(randomQuestion);
        return randomQuestion;
    }

    public bool IsQustionsEmpty()
    {
        if (GetCountOfQuestion() > 0)
        {
            return false;
        }

        return true;
    }

    public int GetCountOfQuestion()
    {
        return _questions.Count;
    }
}
