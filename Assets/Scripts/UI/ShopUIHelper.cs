using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIHelper : MonoBehaviour
{

    [SerializeField] Material[] materialArray;
    [SerializeField] int[] PriceArray;
    [SerializeField] private bool[] CheckIsBuySkinPlayer;
    int currentMoney;

    [SerializeField] Text textPrice;

    [SerializeField] GameObject player;

    Animator anim;


    private void Start()
    {
        index = Setting.indexPlayerMaterial;
        Debug.Log("Setting.indexPlayerMaterial " + Setting.indexPlayerMaterial);
        Debug.Log("index " + index);
        anim = player.GetComponent<Animator>();
        player.GetComponent<Renderer>().material = materialArray[index];
        textPrice.text = PriceArray[index].ToString();

        Setting.PlayerMaterial = player.GetComponent<Renderer>().material;
        Debug.Log(Setting.BoughtMaterialsPlayer);


        for (int i = 0; i < materialArray.Length; i++)
        {
            for (int j = 0; j < Setting.BoughtMaterialsPlayer.Count; j++)
            {
                if (materialArray[i] = Setting.BoughtMaterialsPlayer[j])
                {
                    CheckIsBuySkinPlayer[i] = true;
                    textPrice.text = " Sold ";
                }
            }
        }

    }

    private void Update()
    {
        if (CheckIsBuySkinPlayer[index])
            Setting.PlayerMaterial = player.GetComponent<Renderer>().material;
        

        Setting.indexPlayerMaterial = index;
    }

    private int index;
    public void NextArrow(GameObject panel)
    {
        if (index == materialArray.Length - 1)
            index = 0;
        else
            index++;
        Debug.Log("index " + index);

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
        Debug.Log("index " + index);

        panel.GetComponent<Image>().raycastTarget = true;
        anim.SetBool("newMaterial", true);
        StartCoroutine(ChangePlayer(index, panel));
    }


    IEnumerator ChangePlayer(int i, GameObject pnl)
    {
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<Renderer>().material = materialArray[i];
        
        textPrice.color = Color.black;

        if (!CheckIsBuySkinPlayer[index])
            textPrice.text = PriceArray[index].ToString();
        else
            textPrice.text = " Sold ";

        anim.SetBool("newMaterial", false);
        pnl.GetComponent<Image>().raycastTarget = false;

    }

    public void BuySkinPlayer()
    {
        if (CheckIsBuySkinPlayer[index])
        {
            Debug.Log("_isBuySkin " + CheckIsBuySkinPlayer[index]);
            return;
        }

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
            Debug.Log("BuySkinPlayer() - Setting.moneyValue " + Setting.moneyValue);
            Setting.BoughtMaterialsPlayer.Add(materialArray[index]);
            CheckIsBuySkinPlayer[index] = true;
            textPrice.text = " Sold ";
        }
        else
        {
            textPrice.color = Color.red;
        }
    }
}
