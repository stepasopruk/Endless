using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    [SerializeField] Text _scoreText;
    [SerializeField] Text _bestscoreText;
    public float _score = 0;
    float _speedScore;
    public float _bestScore;

    [Header("Множитель скорости очков")]
    [SerializeField] float multiplierSpeedScore = 5f;

    [SerializeField] RunGeneration run_generation;
    [SerializeField] RunGeneration run_generation1;



    private void Start()
    {
        _speedScore = run_generation.speedRoad;
        _bestScore = Setting.bestScoreValue;
    }

    private void FixedUpdate()
    {
        _score = _score + _speedScore * multiplierSpeedScore * Time.deltaTime;

        float valueScore = ((int)(_score / 2));

        if (_bestScore <= valueScore)
            _bestScore = valueScore;
        _bestscoreText.text = _bestScore.ToString();

        
        _scoreText.text = valueScore.ToString();


        if (valueScore == 50f)
        {
            run_generation.StateGeneration = true;
        }

        if (valueScore >= 100f && valueScore <= 119f)
        {
            run_generation.speedRoad = 6f;
            run_generation1.speedRoad = 6f;
        }

        if (valueScore >= 120f && valueScore <= 139f)
        {
            run_generation.speedRoad = 7f;
            run_generation1.speedRoad = 7f;
        }

        if (valueScore >= 140f && valueScore <= 159f)
        {
            run_generation.speedRoad = 8f;
            run_generation1.speedRoad = 8f;
        }

        if (valueScore >= 160f && valueScore <= 179f)
        {
            run_generation.speedRoad = 9f; 
            run_generation1.speedRoad = 9f;
        }

        if (valueScore >= 180f && valueScore <= 199f)
        {
            run_generation.speedRoad = 10f;
            run_generation1.speedRoad = 10f;
        }

        if (valueScore >= 200f && valueScore <= 219f)
        {
            run_generation.speedRoad = 11f;
            run_generation1.speedRoad = 11f;
        }

        if (valueScore >= 220 && valueScore <= 239f)
        {
            run_generation.speedRoad = 12f;
            run_generation1.speedRoad = 12f;
        }

        if (valueScore >= 240 && valueScore <= 259f)
        {
            run_generation.speedRoad = 13f;
            run_generation1.speedRoad = 13f;
        }

        if (valueScore >= 260f && valueScore <= 279f)
        {
            run_generation.speedRoad = 14f;
            run_generation1.speedRoad = 14f;
        }

        if (valueScore >= 280f && valueScore <= 299f)
        {
            run_generation.speedRoad = 15f;
            run_generation1.speedRoad = 15f;
        }

        if (valueScore >= 300f && valueScore <= 319f)
        {
            run_generation.speedRoad = 16f;
            run_generation1.speedRoad = 16f;
        }

        if (valueScore >= 320f && valueScore <= 339f)
        {
            run_generation.speedRoad = 17f;
            run_generation1.speedRoad = 17f;
        }

        if (valueScore >= 340f && valueScore <= 359f)
        {
            run_generation.speedRoad = 18f;
            run_generation1.speedRoad = 18f;
        }

        if (valueScore >= 360f && valueScore <= 379f)
        {
            run_generation.speedRoad = 19f;
            run_generation1.speedRoad = 19f;
        }

        if (valueScore == 380f)
        {
            run_generation.speedRoad = 20f;
            run_generation1.speedRoad = 20f;

        }

    }
}
