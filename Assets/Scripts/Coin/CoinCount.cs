using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCount : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro totalCoinTxt;
    private Stacking stacking;

    private void Start()
    {
        stacking = GameObject.FindObjectOfType<Stacking>();
        UpdateCoinCount();
    }

    public void UpdateCoinCount()
    {
        //var x = GetComponentsInChildren<Transform>();
        //for (int i = 0; i < x.Length; i++)
        //{
        //    if (x[i].gameObject.tag == "Coin")
        //    {
        //        coins.Add(x[i].gameObject);
        //        x[i].transform.tag = "Untagged";
        //    }
        //}
        totalCoinTxt.text = "$" + stacking.GetCoinCount().ToString();
    }
}
