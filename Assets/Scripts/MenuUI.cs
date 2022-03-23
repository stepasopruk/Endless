using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class MenuUI : MonoBehaviour
{
    [SerializeField] GameObject image_pause;
    [SerializeField] GameObject image_loss;

    public void ButtonPause()
    {
        Time.timeScale = 0;
        image_pause.SetActive(true);
    }

    public void ButtonBack()
    {
        Time.timeScale = 1;
        image_pause.SetActive(false);
        
    }

    public void ButtonExit()
    {
        Application.Quit();
        Debug.Log("Выход из игры");
    }

    [SerializeField] GameObject panel;
    public void LoadScene(int id)
    {
        StartCoroutine(WaitToTransitionCoroutine(panel));
        SceneManager.LoadScene(id);
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

    public void ButtonReload()
    {
        Debug.Log("перезагрузка");
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void ButtonAdvertisement()
    {
        Debug.Log("продолжение");
        image_loss.SetActive(false);
        Time.timeScale = 1;
    }
}
