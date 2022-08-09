using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Quiz _quiz;
    private EndScreen _endScreen;

    private void Start()
    {
        _quiz = FindObjectOfType<Quiz>();
        _endScreen = FindObjectOfType<EndScreen>();
        _quiz.EndEvent.AddListener(ActiveEndScreen);
        _endScreen.gameObject.SetActive(false);
        _quiz.gameObject.SetActive(true);
    }

    private void ActiveEndScreen()
    {
        _endScreen.gameObject.SetActive(true);
        _quiz.gameObject.SetActive(false);
        _quiz.EndEvent.RemoveListener(ActiveEndScreen);
    }

}
