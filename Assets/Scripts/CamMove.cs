using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    //public GameObject Player;
    private Vector3 offset;

    PlayerController _playerController;

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        transform.position = _playerController.transform.position + new Vector3(0, 1.5f, -2.5f);
        offset = transform.position - _playerController.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = _playerController.transform.position + offset;
    }
}
