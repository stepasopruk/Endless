using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIHelper : MonoBehaviour
{

    [SerializeField] Material[] materialArray;

    [SerializeField] GameObject player;
    Material playerMaterial;

    Animator anim;


    private void Start()
    {
        playerMaterial = player.GetComponent<Material>();
        Debug.Log(playerMaterial);
        anim = player.GetComponent<Animator>();
        player.GetComponent<Renderer>().material = materialArray[index];
    }

    int index = 0;
    public void NextArrow()
    {
        if (index == materialArray.Length-1)
            index = 0;
        else
            index++;

        anim.SetBool("newMaterial", true);
        StartCoroutine(ChangePlayer(index));
    }

    public void PrevArrow()
    {
        if (index == 0)
            index = materialArray.Length-1;
        else
            index--;
        
        anim.SetBool("newMaterial", true);

        StartCoroutine(ChangePlayer(index));
    }


    IEnumerator ChangePlayer(int i)
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("ChangePlayer");
        player.GetComponent<Renderer>().material = materialArray[i];
        anim.SetBool("newMaterial", false);

    }
}
