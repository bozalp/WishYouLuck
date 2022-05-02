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
            other.gameObject.tag = "Untagged";
            stacking.AddCube(other.gameObject);
            coinCount.UpdateCoinCount();
            //other.gameObject.tag = "Untagged";
        }
        if(other.gameObject.tag == "Obstacle")
        {
            if(gameObject.GetComponent<MeshCollider>())
            {
                gameObject.GetComponent<AddCoins>().enabled = false;
                gameObject.GetComponent<MeshCollider>().enabled = false;
                stacking.RemoveCoinWithObstacle(gameObject);
            }
        }
    }
}
