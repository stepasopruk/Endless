using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHelper : MonoBehaviour
{
    static int money;
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

        //gameObject.GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject);

    }



}
