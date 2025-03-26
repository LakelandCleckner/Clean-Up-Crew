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
    
    public void AddCoins(int coinsToAdd)
    {
        currentCoins += coinsToAdd;
    }
}
