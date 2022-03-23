using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text scoreText;
    public float _score = 0;
    float speedScore;
    
    [Header("Множитель скорости очков")]
    [SerializeField] float multiplierSpeedScore = 5f;

    [SerializeField] RunGeneration run_generation;
    [SerializeField] RunGeneration run_generation1;



    private void Start()
    {
        speedScore = run_generation.speedRoad;
    }

    private void FixedUpdate()
    {
        _score = _score + speedScore * multiplierSpeedScore * Time.deltaTime;
        scoreText.text = "Score: " + ((int)(_score / 2)).ToString();

        if (((int)(_score / 2)) == 50f)
        {
            run_generation.StateGeneration = true;
        }

        if (((int)(_score / 2)) >= 100f && ((int)(_score / 2)) <= 119f)
        {
            run_generation.speedRoad = 6f;
            run_generation1.speedRoad = 6f;
        }

        if (((int)(_score / 2)) >= 120f && ((int)(_score / 2)) <= 139f)
        {
            run_generation.speedRoad = 7f;
            run_generation1.speedRoad = 7f;
        }

        if (((int)(_score / 2)) >= 140f && ((int)(_score / 2)) <= 159f)
        {
            run_generation.speedRoad = 8f;
            run_generation1.speedRoad = 8f;
        }

        if (((int)(_score / 2)) >= 160f && ((int)(_score / 2)) <= 179f)
        {
            run_generation.speedRoad = 9f; 
            run_generation1.speedRoad = 9f;
        }

        if (((int)(_score / 2)) >= 180f && ((int)(_score / 2)) <= 199f)
        {
            run_generation.speedRoad = 10f;
            run_generation1.speedRoad = 10f;
        }

        if (((int)(_score / 2)) >= 200f && ((int)(_score / 2)) <= 219f)
        {
            run_generation.speedRoad = 11f;
            run_generation1.speedRoad = 11f;
        }

        if (((int)(_score / 2)) >= 220 && ((int)(_score / 2)) <= 239f)
        {
            run_generation.speedRoad = 12f;
            run_generation1.speedRoad = 12f;
        }

        if (((int)(_score / 2)) >= 240 && ((int)(_score / 2)) <= 259f)
        {
            run_generation.speedRoad = 13f;
            run_generation1.speedRoad = 13f;
        }

        if (((int)(_score / 2)) >= 260f && ((int)(_score / 2)) <= 279f)
        {
            run_generation.speedRoad = 14f;
            run_generation1.speedRoad = 14f;
        }

        if (((int)(_score / 2)) >= 280f && ((int)(_score / 2)) <= 299f)
        {
            run_generation.speedRoad = 15f;
            run_generation1.speedRoad = 15f;
        }

        if (((int)(_score / 2)) >= 300f && ((int)(_score / 2)) <= 319f)
        {
            run_generation.speedRoad = 16f;
            run_generation1.speedRoad = 16f;
        }

        if (((int)(_score / 2)) >= 320f && ((int)(_score / 2)) <= 339f)
        {
            run_generation.speedRoad = 17f;
            run_generation1.speedRoad = 17f;
        }

        if (((int)(_score / 2)) >= 340f && ((int)(_score / 2)) <= 359f)
        {
            run_generation.speedRoad = 18f;
            run_generation1.speedRoad = 18f;
        }

        if (((int)(_score / 2)) >= 360f && ((int)(_score / 2)) <= 379f)
        {
            run_generation.speedRoad = 19f;
            run_generation1.speedRoad = 19f;
        }

        if (((int)(_score / 2)) == 380f)
        {
            run_generation.speedRoad = 20f;
            run_generation1.speedRoad = 20f;

        }

    }
}
