using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class RouletteGate : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro redTxt, blackTxt;
    [SerializeField]
    private GameObject roulette;
    [SerializeField]
    private GameObject[] coins;
    private int redCounter = 0, blackCounter = 0;
    private PlayerMovement playerMovement;
    private Stacking stacking;
    private RouletteBall ball;
    private float tempSpeed;
    private bool goForward;
    private void Start()
    {
        DOTween.Init();
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        ball = GameObject.FindObjectOfType<RouletteBall>();
        stacking = GameObject.FindObjectOfType<Stacking>();
        tempSpeed = playerMovement.ForwardSpeed;
    }
    private void Update()
    {
        if (ball.showResult && !goForward)
        {
            goForward = true;
            if (ball.isRed)
            {
                for (int i = 0; i < redCounter * 2; i++)
                {
                    GameObject coin = Instantiate(coins[Random.Range(0, coins.Length)], transform);
                    stacking.AddCoin(coin);
                }
            }
            else
            {
                for (int i = 0; i < blackCounter * 2; i++)
                {
                    GameObject coin = Instantiate(coins[Random.Range(0, coins.Length)], transform);
                    stacking.AddCoin(coin);
                }
            }
            Invoke("GoRunning", 1f);
        }
    }
    private void GoRunning()
    {
        roulette.transform.DOMoveY(-10, 1f).OnComplete
            (() =>
            {
                DOTween.To(() => playerMovement.ForwardSpeed, x => playerMovement.ForwardSpeed = x, tempSpeed, .1f);
                AnimationManager.instance.StartRunAnimation();
            });
        stacking.stopMovement = false;
    }

    public int ReCounter
    {
        get
        {
            return redCounter;
        }
    }
    public int BlackCounter
    {
        get
        {
            return blackCounter;
        }
    }

    public void UpdateRouletteTexts(bool isRed)
    {
        if (isRed)
        {
            redCounter++;
            redTxt.text = "$" + redCounter.ToString();
        }
        else
        {
            blackCounter++;
            blackTxt.text = "$" + blackCounter.ToString();
        }

    }
}
