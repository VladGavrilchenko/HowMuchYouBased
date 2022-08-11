using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{

    [SerializeField] private Button restartButton;
    public void RestartSceneButton()
    {
        AdsManager.Instance.ShowAd(this);
        restartButton.interactable = false;
    }

    public void RestartScene()
    {
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneBuildIndex);
    }
}
