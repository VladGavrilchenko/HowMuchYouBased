using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerButton : MonoBehaviour
{
    private Image _buttonImage;
    private Button _button;
    private TextMeshProUGUI _buttonText;

    private void Awake()
    {
        _buttonImage = GetComponent<Image>();
        _button = GetComponent<Button>();
        _buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetSpriteButtonImage(Sprite newSprite)
    {
        _buttonImage.sprite = newSprite;
    }

    public void SetState(bool state)
    {
        _button.interactable = state;
    }

    public void SetButtonText(string newText)
    {
        _buttonText.text = newText;
    }
}
