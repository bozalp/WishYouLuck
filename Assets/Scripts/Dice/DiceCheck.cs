using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DiceCheck : MonoBehaviour
{
    [SerializeField]
    private Gate diceGate;
    private Stacking stacking;
    public Dice dice;
    public bool odd;
    private int diceNum1, diceNum2, total;
    [SerializeField]
    private GameObject[] coins;
    private bool control;
    [SerializeField]
    private GameObject dice1, dice2;
    private PlayerMovement playerMovement;
    private float tempSpeed;
    private void Start()
    {
        DOTween.Init();
        stacking = GameObject.FindObjectOfType<Stacking>();
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        tempSpeed = playerMovement.ForwardSpeed;
    }

    private void Update()
    {
        if (stacking.stopDiceGate && !control)
        {
            Invoke("DiceControl", 4f);
            control = true;
            stacking.stopDiceGate = false;
        }
    }
    public void DiceControl()
    {
        total = diceNum1 + diceNum2;
        if (total % 2 == 0)
        {
            odd = false;
            int evetCount = diceGate.EvenCount * 2;
            for (int i = 0; i < evetCount; i++)
            {
                GameObject coin = Instantiate(coins[Random.Range(0, coins.Length)], transform);
                stacking.AddCoin(coin);
            }
        }
        else
        {
            odd = true;
            int oddCount = diceGate.OddCount * 2;
            for (int i = 0; i < oddCount; i++)
            {
                GameObject coin = Instantiate(coins[Random.Range(0, coins.Length)], transform);
                stacking.AddCoin(coin);
            }
        }
        Invoke("GoRunning", 1f);        
    }
    private void GoRunning()
    {
        dice1.transform.DOMoveY(-5, 1f);
        dice2.transform.DOMoveY(-5, 1f);
        DOTween.To(() => playerMovement.ForwardSpeed, x => playerMovement.ForwardSpeed = x, tempSpeed, .5f);
        AnimationManager.instance.StartRunAnimation();
    }
    private void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.name)
        {
            case "1":
                other.gameObject.GetComponent<BoxCollider>().enabled = false;
                diceNum1 = 6;
                break;
            case "2":
                diceNum1 = 4; other.gameObject.GetComponent<BoxCollider>().enabled = false;
                break;
            case "3":
                diceNum1 = 5; other.gameObject.GetComponent<BoxCollider>().enabled = false;
                break;
            case "4":
                diceNum1 = 2; other.gameObject.GetComponent<BoxCollider>().enabled = false;
                break;
            case "5":
                diceNum1 = 3; other.gameObject.GetComponent<BoxCollider>().enabled = false;
                break;
            case "6":
                diceNum1 = 1; other.gameObject.GetComponent<BoxCollider>().enabled = false;
                break;
        }
        switch (other.gameObject.name)
        {
            case "11":
                diceNum2 = 6; other.gameObject.GetComponent<BoxCollider>().enabled = false;
                break;
            case "22":
                diceNum2 = 4; other.gameObject.GetComponent<BoxCollider>().enabled = false;
                break;
            case "33":
                diceNum2 = 5; other.gameObject.GetComponent<BoxCollider>().enabled = false;
                break;
            case "44":
                diceNum2 = 2; other.gameObject.GetComponent<BoxCollider>().enabled = false;
                break;
            case "55":
                diceNum2 = 3; other.gameObject.GetComponent<BoxCollider>().enabled = false;
                break;
            case "66":
                diceNum2 = 1; other.gameObject.GetComponent<BoxCollider>().enabled = false;
                break;
        }
    }
}