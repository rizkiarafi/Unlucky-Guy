using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    Coins coinsScr;

    void Awake()
    {
        coinsScr = FindObjectOfType<Coins>();

        coinsScr.SetCoins(PlayerPrefs.GetInt("Coins"));

        coinsScr.SetCoinsText(PlayerPrefs.GetInt("Coins").ToString());
    }


    public void SaveGame()
    {
        PlayerPrefs.SetInt("Coins", coinsScr.GetCoins());
    } 
}
