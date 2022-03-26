using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHelper : MonoBehaviour
{
    int money = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Enrol()
    {
        money++;
        Setting.moneyValue = money;
        Debug.Log("Setting.moneyValue " + Setting.moneyValue);
        Debug.Log("money " + money);
    }

 
}
