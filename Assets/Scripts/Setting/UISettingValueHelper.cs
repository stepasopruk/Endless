using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettingValueHelper : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Slider sliderSound;
    [SerializeField] Text bestScore;
    [SerializeField] Text textMoney;

    void Start()
    {
        sliderSound.value = Setting.soundValue;
        bestScore.text = Setting.bestScoreValue.ToString();
        textMoney.text = Setting.moneyValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        textMoney.text = Setting.moneyValue.ToString();
        Setting.soundValue = sliderSound.value;
        PlayerPrefs.SetFloat("soundValue", Setting.soundValue);
    }
}
