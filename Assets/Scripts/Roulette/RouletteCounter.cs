using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteCounter : MonoBehaviour
{
    [SerializeField]
    private RouletteGate rouletteGate;
    [SerializeField]
    private bool red;
    private Stacking stacking;

    private void Start()
    {
        stacking = GameObject.FindObjectOfType<Stacking>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<AddCoins>() != null && !other.gameObject.GetComponent<BoxCollider>())
        {
            stacking.stopRouletteGate = true;
            Destroy(other.gameObject);
            rouletteGate.UpdateRouletteTexts(red);
            stacking.RemoveCoin(other.gameObject);
        }
    }
}
