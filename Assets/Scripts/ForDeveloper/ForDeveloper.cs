using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForDeveloper : MonoBehaviour
{
    public void AddCoin()
    {
        Setting.moneyValue = Setting.moneyValue + 1000;
    }
}
