using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceGate : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro oddTxt, evenTxt;
    private int oddCounter = 0, evenCounter = 0;

    public int OddCount
    {
        get
        {
            return oddCounter;
        }
    } 
    public int EvenCount
    {
        get
        {
            return evenCounter;
        }
    }

    public void UpdateDiceTexts(bool isOdd)
    {
        if(isOdd)
        {
            oddCounter++;
            oddTxt.text = "$" + oddCounter.ToString();
        }
        else
        {
            evenCounter++;
            evenTxt.text = "$" + evenCounter.ToString();
        }
        
    }
}
