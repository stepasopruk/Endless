using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public void ButtonMenu()
    {
        Debug.Log("Выход в меню");
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
