using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject image_loss;
    [SerializeField] Score score;
    [SerializeField] Text scoreTextLoss;

    public void End()
    {
        Time.timeScale = 0;
        scoreTextLoss.text = "Ваш счет: " + ((int)(score._score / 2)).ToString();
        image_loss.SetActive(true);
    }
}
