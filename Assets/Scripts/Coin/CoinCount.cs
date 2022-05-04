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
    private void Update()
    {
        UpdateCoinCount();
    }

    public void UpdateCoinCount()
    {
        totalCoinTxt.text = "$" + stacking.GetCoinCount().ToString();
    }
}
