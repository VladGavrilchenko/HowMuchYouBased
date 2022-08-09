using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class FriendCall : MonoBehaviour
{
    [SerializeField] private Image _portret;
    [SerializeField] private TextMeshProUGUI _friendsAnswer;
    [SerializeField] private FriendSO[] _friends;
    [SerializeField] private Button _button;
    private IQuiz _iquiz;
    private bool _isUse;

    private void Start()
    {
        SetAnswerVisibly(false);
        Quiz quiz = FindObjectOfType<Quiz>();
        quiz.AnswerEvent.AddListener(CloseTooltip);
        _iquiz = FindObjectOfType<Quiz>().GetComponent<IQuiz>();
    }

    public void SetAnswerVisibly(bool isVisily)
    {
        _portret.enabled = isVisily;
        _friendsAnswer.enabled = isVisily;
    }

    public void CallFriend()
    {
        int randomFriend =  Random.Range(0, _friends.Length);
        _portret.sprite = _friends[randomFriend].GetImage();
        _friendsAnswer.text = _friends[randomFriend].GetGreeting() + GetFriendAnswer();
        SetAnswerVisibly(true);
        _isUse = true;
        _button.interactable = false;
    }

    private string GetFriendAnswer()
    {
        bool isknow = Random.Range(0,2) == 0;

        if (isknow)
        {
            return (_iquiz.GetCurrentQustion().GetAnswer(_iquiz.GetCurrentQustion().Get—orrectAnswerIndex())).ToString();
        }

        return _iquiz.GetCurrentQustion().GetAnswer(Random.Range(1, 4)).ToString();
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
