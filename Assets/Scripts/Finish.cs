using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private Stacking stacking;

    private void Start()
    {
        stacking = GameObject.FindObjectOfType<Stacking>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<AddCoins>() != null && !other.gameObject.GetComponent<BoxCollider>())
        {
            stacking.stopFinish = true;
            Destroy(other.gameObject);
            stacking.RemoveCoin(other.gameObject);
        }
    }
}
