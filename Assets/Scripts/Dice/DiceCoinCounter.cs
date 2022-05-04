using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceCoinCounter : MonoBehaviour
{
    [SerializeField]
    private Gate gateParent;
    [SerializeField]
    private bool odd;
    private Stacking stacking;

    private void Start()
    {
        stacking = GameObject.FindObjectOfType<Stacking>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<AddCoins>() != null && !other.gameObject.GetComponent<BoxCollider>())
        {
            stacking.stopDiceGate = true;
            Destroy(other.gameObject);
            gateParent.UpdateDiceTexts(odd);
            stacking.RemoveCoin(other.gameObject);   
        }
    }
}
