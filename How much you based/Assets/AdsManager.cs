using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool testMode = true;
    public static AdsManager Instance;

#if UNITY_ANDROID
    private string gameId = "4881561";
#elif UNITY_IOS
     private string gameId = "4881560";
#endif

    private Restart restart;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId, testMode);
        }
    }

    public void ShowAd(Restart restart)
    {
        this.restart = restart;
        Advertisement.Show("rewardedTest");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ad Ready");
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad Started");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished:
                restart.RestartScene();
                break;
            case ShowResult.Skipped:
                restart.RestartScene();
                break;
            case ShowResult.Failed:
                Debug.Log(showResult.ToString());
                break;
        }
    }

}
