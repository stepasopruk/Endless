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

    Animator animCam;
    //Animator animPanel;

    [SerializeField] Camera camera;
    private void Start()
    {
        Time.timeScale = 1;
        animCam = camera.GetComponent<Animator>();

        //animPanel = panel.GetComponent<Animator>();
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Выход из игры");
    }


    public void Setting()
    {
        StartCoroutine(WaitToActiveCoroutine(button_setting, panel_setting));
        animCam.SetBool("TransitionSetting", true);

    }

    public void BestScore()
    {
        StartCoroutine(WaitToActiveCoroutine(button_score, panel_score));

        animCam.SetBool("TransitionBestScore", true);
    }

    public void BackButtonSetting()
    {
        StartCoroutine(WaitToActiveCoroutine(panel_setting, button_setting));

        animCam.SetBool("TransitionSetting", false);
    }

    public void BackButtonScore()
    {
        StartCoroutine(WaitToActiveCoroutine(panel_score, button_score));

        animCam.SetBool("TransitionBestScore", false);
    }

    IEnumerator WaitToActiveCoroutine(GameObject obj1, GameObject obj2)
    {
        yield return new WaitForSeconds(1);
        
        obj1.SetActive(false);
        obj2.SetActive(true);

    }


    //[SerializeField] GameObject panel;
    //public void LoadScene(int id)
    //{
    //    StartCoroutine(WaitToTransitionCoroutine(panel, id));  
    //}

    //Color newcolor = new Color(0f, 0f, 0f, 0f);


    //IEnumerator WaitToTransitionCoroutine(GameObject obj, int id)
    //{

    //    yield return new WaitForSeconds(0.005f);

    //    obj.GetComponent<Image>().color = newcolor;

    //    if (newcolor.a < 1f)
    //    {
    //        newcolor.a+= 0.02f;
    //        Debug.Log(newcolor);
    //        StartCoroutine(WaitToTransitionCoroutine(obj, id));
    //    }else if(newcolor.a >= 1f)
    //    {
    //        SceneManager.LoadScene(id);
    //    }

    //}

    public void LoadScene(int id)
    {
        SceneManager.LoadScene(id);
    }

}
