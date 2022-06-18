using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{

    [SerializeField] private string _androidAdsUnitId = "Interstitial_Android";
    [SerializeField] private string _i0SAdsUnitId= "Interstitial_iOS";
    private string _adsUnitId;

    private void Awake()
    {
        _adsUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
        ? _i0SAdsUnitId
        : _androidAdsUnitId;
        LoadAds();
    }

    public void LoadAds()
    {
        Debug.Log("Loading Ads: " + _adsUnitId);
        Advertisement.Load(_adsUnitId, this);
    }

    public void ShowAds()
    {
        Debug.Log("Showing Ads: " + _adsUnitId);
        Advertisement.Show(_adsUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        // Optionally execute code if the Ad Unit successfully loads content.
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {_adsUnitId} - {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowClick(string placementId){ }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        LoadAds();
        Time.timeScale = 1;
    }


    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit: {_adsUnitId} - {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId) { }
}
