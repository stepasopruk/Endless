using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private Button _buttonAdvertisement;

    [SerializeField] private string _androidAdsUnitId = "Rewarded_Android";
    [SerializeField] private string _i0SAdsUnitId = "Rewarded_iOS";
    private string _adsUnitId;

    private void Awake()
    {
        _adsUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
        ? _i0SAdsUnitId
        : _androidAdsUnitId;
    }

    private void Start()
    {
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
        Debug.Log("Ad Loaded:" + placementId);
        if (placementId.Equals(_adsUnitId))
        {
            _buttonAdvertisement.onClick.AddListener(ShowAds);
        }
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {_adsUnitId} - {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit: {_adsUnitId} - {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId){ }

    public void OnUnityAdsShowClick(string placementId){ }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId.Equals(_adsUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            Time.timeScale = 1;
            _buttonAdvertisement.interactable = false;
        }
    }

    private void OnDestroy()
    {
        _buttonAdvertisement.onClick.RemoveAllListeners();
    }
}
