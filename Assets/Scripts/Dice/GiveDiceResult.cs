using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDiceResult : MonoBehaviour
{
    Rigidbody rb;
    private bool diceStoped;
    public int diceNum;
    private Stacking stacking;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        stacking = GameObject.FindObjectOfType<Stacking>();
    }

    private void Update()
    {
        if(rb.velocity == Vector3.zero && !diceStoped && stacking.stopDiceGate)
        {
            stacking.stopDiceGate = false;

            Invoke("diceStop", 1f);
        }
    }
    private void diceStop()
    {
        diceStoped = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (diceStoped)
        {            
            switch (other.gameObject.name)
            {
                case "1":
                    diceNum = 6;
                    break;
                case "2":
                    diceNum = 4;
                    break;
                case "3":
                    diceNum = 5;
                    break;
                case "4":
                    diceNum = 2;
                    break;
                case "5":
                    diceNum = 3;
                    break;
                case "6":
                    diceNum = 1;
                    break;
            }
        }
    }
}
