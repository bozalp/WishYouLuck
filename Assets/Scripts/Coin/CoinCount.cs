using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCount : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro totalCoinTxt;
    private List<GameObject> coins = new List<GameObject>();

    private void Start()
    {
        UpdateCoinCount();
    }

    public void UpdateCoinCount()
    {
        var x = GetComponentsInChildren<Transform>();
        for (int i = 0; i < x.Length; i++)
        {
            if (x[i].gameObject.tag == "Coin")
            {
                coins.Add(x[i].gameObject);
                x[i].transform.tag = "Untagged";
            }
        }
        totalCoinTxt.text = "$" + coins.Count.ToString();
    }
}
