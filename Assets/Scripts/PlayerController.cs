using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameManager endGame;
    Vector3 targetPos;
    float laneOffset = 1f;
    float laneChangeSpeed = 15;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClipCoinSelection;


    void Start()
    {
        targetPos = transform.position;
        SwipeDetection.instance.MoveEvent += MovePlayer;
        _audioSource = GetComponent<AudioSource>();
    }

    void MovePlayer(bool[] swipes)
    {
        if (swipes[(int)SwipeDetection.Direction.Left] && targetPos.x > -laneOffset)
        {
            targetPos = new Vector3(targetPos.x - laneOffset, transform.position.y, transform.position.z);
        }
        if (swipes[(int)SwipeDetection.Direction.Right] && targetPos.x < laneOffset)
        {
            targetPos = new Vector3(targetPos.x + laneOffset, transform.position.y, transform.position.z);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            targetPos = new Vector3(targetPos.x - laneOffset, transform.position.y, transform.position.z);
            Debug.Log("LeftArrow");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetPos = new Vector3(targetPos.x + laneOffset, transform.position.y, transform.position.z);
            Debug.Log("RightArrow");
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, laneChangeSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CoinHelper>())
        {
            other.GetComponent<CoinHelper>().Enrol();
            _audioSource.PlayOneShot(_audioClipCoinSelection);
        }
        else
        {
            Debug.Log("Конец игры");
            endGame.End();
        }
    }

}
