using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHelper : MonoBehaviour
{

    [SerializeField] GameObject button_setting;
    [SerializeField] GameObject panel_setting;

    [SerializeField] GameObject panel_score;
    [SerializeField] GameObject button_score;

    Animator anim;

    [SerializeField] Camera camera;
    private void Start()
    {
        Time.timeScale = 1;
        anim = camera.GetComponent<Animator>();


    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Выход из игры");
    }


    public void Setting()
    {
        StartCoroutine(WaitToActiveCoroutine(button_setting, panel_setting));
        anim.SetBool("TransitionSetting", true);

    }

    public void BestScore()
    {
        StartCoroutine(WaitToActiveCoroutine(button_score, panel_score));

        anim.SetBool("TransitionBestScore", true);
    }

    public void BackButtonSetting()
    {
        StartCoroutine(WaitToActiveCoroutine(panel_setting, button_setting));

        anim.SetBool("TransitionSetting", false);
    }

    public void BackButtonScore()
    {
        StartCoroutine(WaitToActiveCoroutine(panel_score, button_score));

        anim.SetBool("TransitionBestScore", false);
    }

    IEnumerator WaitToActiveCoroutine(GameObject obj1, GameObject obj2)
    {
        yield return new WaitForSeconds(1);
        
        obj1.SetActive(false);
        obj2.SetActive(true);

    }

    [SerializeField] GameObject panel;
    public void LoadScene(int id)
    {
        StartCoroutine(WaitToTransitionCoroutine(panel));
        //SceneManager.LoadScene(id);
    }

    IEnumerator WaitToTransitionCoroutine(GameObject obj)
    {
        yield return new WaitForSeconds(1f);
        Color panel;
        panel = GetComponent<Image>().color;

        while (panel.a < 255f)
        {
            Debug.Log(panel.a);
            panel.a++;
            StartCoroutine(WaitToTransitionCoroutine(obj));
        }


    }

}
