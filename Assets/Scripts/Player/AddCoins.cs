using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCoins : MonoBehaviour
{
    private Stacking stacking;
    private CoinCount coinCount;
    private void Start()
    {
        stacking = GameObject.FindObjectOfType<Stacking>();
        coinCount = GameObject.FindObjectOfType<CoinCount>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            stacking.AddCube(other.gameObject);
            coinCount.UpdateCoinCount();
            //other.gameObject.tag = "Untagged";
        }
    }
}
