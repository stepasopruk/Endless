using UnityEngine;
using UnityEngine.Advertisements;

public class MonetizationAds : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private bool _testMode = true;

    [SerializeField] private string _androidGameId = "4794960";
    [SerializeField] private string _iOSGameId = "4794961";

    private string _gameId;

    private void Awake()
    {
        InitializeAds();
    }
    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iOSGameId : _androidGameId;
        Debug.Log("GameId: " + _gameId);
        Advertisement.Initialize(_gameId, _testMode, this);
    }

    void IUnityAdsInitializationListener.OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    void IUnityAdsInitializationListener.OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}
