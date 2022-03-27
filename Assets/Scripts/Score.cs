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

    float valueScore;
    private void FixedUpdate()
    {
        _score = _score + _speedScore * multiplierSpeedScore * Time.deltaTime;

        valueScore = ((int)(_score / 2));

        if (_bestScore <= valueScore)
            _bestScore = valueScore;
        _bestscoreText.text = _bestScore.ToString();

        _scoreText.text = valueScore.ToString();

        SpeedRoadController();


    }
    float range = 100f;
    float valueSpeed = 6f;
    void SpeedRoadController()
    {
        if (valueScore == 50f)
        {
            run_generation.StateGeneration = true;
        }

        if (valueScore >= range && valueSpeed <= 20)
        {
            run_generation.speedRoad = valueSpeed;
            run_generation1.speedRoad = valueSpeed;
            valueSpeed++;
            range = range + 200f;
        }
    }
}
