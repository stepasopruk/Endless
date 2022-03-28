using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIHelper : MonoBehaviour
{

    [SerializeField] Material[] materialArray;
    [SerializeField] int[] PriceArray;
    int currentMoney;

    [SerializeField] Text textPrice;

    [SerializeField] GameObject player;

    Animator anim;


    private void Start()
    {
        anim = player.GetComponent<Animator>();
        player.GetComponent<Renderer>().material = materialArray[index];
        textPrice.text = PriceArray[index].ToString();
    }

    int index = 0;
    public void NextArrow(GameObject panel)
    {
        if (index == materialArray.Length-1)
            index = 0;
        else
            index++;
        
        panel.GetComponent<Image>().raycastTarget = true;
        anim.SetBool("newMaterial", true);
        StartCoroutine(ChangePlayer(index, panel));
    }

    public void PrevArrow(GameObject panel)
    {
        if (index == 0)
            index = materialArray.Length-1;
        else
            index--;
        panel.GetComponent<Image>().raycastTarget = true;
        anim.SetBool("newMaterial", true);
        StartCoroutine(ChangePlayer(index, panel));
    }


    IEnumerator ChangePlayer(int i, GameObject pnl)
    {
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<Renderer>().material = materialArray[i];
        textPrice.text = PriceArray[index].ToString();
        anim.SetBool("newMaterial", false);
        pnl.GetComponent<Image>().raycastTarget = false;

    }
}
