using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static CoinController instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public int currentCoins;

    public CoinPickup coin;
    public void AddCoins(int coinsToAdd)
    {
        currentCoins += coinsToAdd;

        UIController.instance.UpdateCoins();

        SFXManager.instance.PlaySFXPitched(2);

    }

    public void DropCoin(Vector3 position, int value)
    {
        CoinPickup newCoin = Instantiate(coin, position + new Vector3(.2f, .1f, 0), Quaternion.identity);
        newCoin.coinAmount = value;
        newCoin.gameObject.SetActive(true);
    }

    public void SpendCoins(int coinsToSpend)
    {
        currentCoins -= coinsToSpend;
        UIController.instance.UpdateCoins();
    }
}
