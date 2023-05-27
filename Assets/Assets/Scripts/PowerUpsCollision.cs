using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsCollision : CoinCollision
{

    protected override void AddEffect()
    {
        if (sentence == "2xCoins")
        {
            coinsScr.AddCoin(2);
            audio.AddCoinSound(1);
        }

        else if (sentence == "Shield")
        {
            powerUpsScr.ActivateShield();
        }

    }
}
