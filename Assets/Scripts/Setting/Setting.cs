using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Setting
{
    public static float soundValue = 0.5f;
    public static float bestScoreValue = 0;
    public static int moneyValue = 0;


    public static Material PlayerMaterial;

    public static int indexPlayerMaterial = 0;

    public static List<Material> BoughtMaterialsPlayer = new List<Material>();

    //public static Dictionary<int, Material> BoughtMaterialsPlayer = new Dictionary<int, Material>();

    public static void onStart()
    {
        soundValue = PlayerPrefs.GetFloat("soundValue");
        bestScoreValue = PlayerPrefs.GetFloat("bestScoreValue");
        moneyValue = PlayerPrefs.GetInt("moneyValue");
    }


}
