using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHelper : MonoBehaviour
{

    [SerializeField] GameObject button_setting;
    [SerializeField] GameObject button_score;

    Animator anim;

    [SerializeField] Camera camera;
    private void Start()
    {
        anim = camera.GetComponent<Animator>();
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Выход из игры");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Setting()
    {
        StartCoroutine(WaitCoroutine(button_setting));
        anim.SetBool("TransitionSetting", true);

    }

    IEnumerator WaitCoroutine(GameObject obj)
    {
        yield return new WaitForSeconds(1);
        obj.SetActive(false);
    }

    public void BestScore()
    {
        StartCoroutine(WaitCoroutine(button_score));
        anim.SetBool("TransitionBestScore", true);
    }


}
