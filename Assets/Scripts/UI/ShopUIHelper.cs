using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIHelper : MonoBehaviour
{

    [SerializeField] private Material[] materialArray;
    [SerializeField] int[] PriceArray;
    [SerializeField] private bool[] CheckIsBuySkinPlayer;
    private int index;
    private bool _isActiveCoroutine;
    [SerializeField] Text textPrice;

    [SerializeField] GameObject player;

    Animator anim;

    private void Awake()
    {
        index = Setting.indexPlayerMaterial;
        anim = player.GetComponent<Animator>();
        player.GetComponent<Renderer>().material = materialArray[index];
        textPrice.text = PriceArray[index].ToString();
        Setting.PlayerMaterial = materialArray[0];
    }

    private void Start()
    {
        for (int i = 0; i < materialArray.Length; i++)
        {
            for (int j = 0; j < Setting.BoughtMaterialsPlayer.Count; j++)
            {
                if (materialArray[i] == Setting.BoughtMaterialsPlayer[j])
                {
                    CheckIsBuySkinPlayer[i] = true;
                }
            }
        }
    }

    private void Update()
    {
        if (CheckIsBuySkinPlayer[index] && !_isActiveCoroutine)
        {
            Setting.PlayerMaterial = player.GetComponent<Renderer>().material;
            textPrice.text = " Sold ";
            textPrice.color = new Color(0.728907f, 0.7825828f, 0.7924528f, 1f);
        }
        else if(!_isActiveCoroutine)
            textPrice.text = PriceArray[index].ToString();

        Setting.indexPlayerMaterial = index;

        Debug.Log("PlayerMaterial " + Setting.PlayerMaterial);
    }


    public void NextArrow(GameObject panel)
    {
        if (index == materialArray.Length - 1)
            index = 0;
        else
            index++;

        _isActiveCoroutine = true;
        textPrice.text = "";
        panel.GetComponent<Image>().raycastTarget = true;
        anim.SetBool("newMaterial", true);
        StartCoroutine(ChangePlayer(index, panel));
    }

    public void PrevArrow(GameObject panel)
    {
        if (index == 0)
            index = materialArray.Length - 1;
        else
            index--;

        _isActiveCoroutine = true;
        textPrice.text = "";
        panel.GetComponent<Image>().raycastTarget = true;
        anim.SetBool("newMaterial", true);
        StartCoroutine(ChangePlayer(index, panel));
    }


    IEnumerator ChangePlayer(int i, GameObject pnl)
    {
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<Renderer>().material = materialArray[i];

        textPrice.color = new Color(0.945098f, 0.7921569f, 0.2470588f, 1f);

        if (!CheckIsBuySkinPlayer[index])
            textPrice.text = PriceArray[index].ToString();
        else
        {
            textPrice.text = " Sold ";
        }

        anim.SetBool("newMaterial", false);
        pnl.GetComponent<Image>().raycastTarget = false;

        _isActiveCoroutine = false;

    }

    public void BuySkinPlayer()
    {
        if (CheckIsBuySkinPlayer[index])
            return;


        //for(int i = 0; i < materialArray.Length; i++)
        //{
        //    if (player.GetComponent<Renderer>().material = materialArray[i])
        //    {
        //        index = i;
        //        Debug.Log("BuySkinPlayer() - index " + index);
        //    }
        //}

        if (Setting.moneyValue >= PriceArray[index])
        {
            Setting.moneyValue -= PriceArray[index];
            Setting.BoughtMaterialsPlayer.Add(materialArray[index]);
            CheckIsBuySkinPlayer[index] = true;
            textPrice.text = " Sold ";
        }
        else
        {
            textPrice.color = new Color(0.945098f, 0.3997653f, 0.2470588f, 1f);
        }
    }
}
