using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Friend", fileName = "New Friend")]
public class FriendSO : ScriptableObject
{
    [SerializeField] private Sprite _portret;
    [SerializeField] private string _textGreeting;

    public Sprite GetImage()
    {
        return _portret;
    }

    public string GetGreeting()
    {
        return _textGreeting;
    }

}
