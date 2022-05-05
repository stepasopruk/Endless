using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHelper : MonoBehaviour
{
    static int money;
    void Start()
    {
        money = Setting.moneyValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Enrol()
    {
        money++;
        Setting.moneyValue = money;
        PlayerPrefs.SetInt("moneyValue", Setting.moneyValue);
        //gameObject.GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject);

    }



}
