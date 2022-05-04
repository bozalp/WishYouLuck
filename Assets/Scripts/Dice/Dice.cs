using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public GameObject leftDice, rightDice;

    public void toDice()
    {
        leftDice.GetComponent<Rigidbody>().useGravity = true;
        rightDice.GetComponent<Rigidbody>().useGravity = true;
        float dirX = Random.Range(100, 500);
        float dirY = Random.Range(100, 250);
        float dirZ = Random.Range(100, 500);
        transform.rotation = Quaternion.identity;
        leftDice.GetComponent<Rigidbody>().AddForce(transform.up * Random.Range(5, 10), ForceMode.Impulse);
        rightDice.GetComponent<Rigidbody>().AddForce(transform.up * Random.Range(5, 10), ForceMode.Impulse);
        leftDice.GetComponent<Rigidbody>().AddTorque(dirX, dirY, dirZ);
        rightDice.GetComponent<Rigidbody>().AddTorque(dirX, dirY, dirZ);
    }
}
