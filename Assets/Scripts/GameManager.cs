using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject image_loss;
    [SerializeField] Score score;
    [SerializeField] Text scoreTextLoss;

    private PlayerController _playerController;

    //private void Awake()
    //{
    //    InterstitialAds.S.LoadAds();
    //}
    private void Start()
    {
        Time.timeScale = 1;
        _playerController = FindObjectOfType<PlayerController>();
        _playerController.GetComponent<Renderer>().material = Setting.PlayerMaterial;
    }

    public void End()
    {
        Time.timeScale = 0;
        scoreTextLoss.text = ((int)(score._score / 2)).ToString();
        Setting.bestScoreValue = score._bestScore;
        image_loss.SetActive(true);
    }
}
