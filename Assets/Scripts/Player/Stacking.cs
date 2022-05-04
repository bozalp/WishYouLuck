using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stacking : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> coins;
    [SerializeField]
    private float swingValue = .3f;
    [SerializeField]
    private float swipeSpeed, rightMovementLimitPos, leftMovementLimitPos, forwardSpeed = 8, coinForwardPosition;
    private CoinCount coinCount;
    private GameObject currCoin, prevCoin;
    private Vector3 inputDrag, preMousePos;
    private PlayerMovement playerMovement;
    private bool beforeFinish;
    [HideInInspector]
    public bool stopDiceGate, stopFinish, stopRouletteGate, stopMovement;
    public int totalCoinBeforeFinish;
    private Dice dice;
    private Roulette roulette;
    private FinishCoinCreate FinishCoinCreate;
    private void Start()
    {
        DOTween.Init();
        coinCount = GameObject.FindObjectOfType<CoinCount>();
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        FinishCoinCreate = GameObject.FindObjectOfType<FinishCoinCreate>();
        dice = GameObject.FindObjectOfType<Dice>();
        roulette = GameObject.FindObjectOfType<Roulette>();
    }

    public void AddCoin(GameObject collectedCoin)
    {
        collectedCoin.gameObject.tag = "Untagged";
        collectedCoin.transform.localEulerAngles = new Vector3(Random.Range(0, 360), -90, 90);
        float tempForwardPosition = coinForwardPosition;
        coins.Add(collectedCoin);
        collectedCoin.transform.parent = gameObject.transform;
        collectedCoin.transform.localPosition = new Vector3(coins[coins.Count - 2].transform.localPosition.x, 5,
        coins[coins.Count - 2].transform.localPosition.z + coinForwardPosition);
    }
    public void RemoveCoinWithObstacle(GameObject crashedCoin)
    {
        int crashedCoinIndex = coins.IndexOf(crashedCoin.transform.gameObject);
        int y = coins.Count;
        if (crashedCoinIndex > 2)
            for (int i = y - 1; i > crashedCoinIndex; i--)
            {
                coins[i].GetComponent<AddCoins>().enabled = false;
                coins[i].GetComponent<MeshCollider>().enabled = false;
            }
    }
    public void RemoveCoinWithFinish(GameObject coin)
    {
        coin.GetComponent<AddCoins>().enabled = false;
        coin.GetComponent<MeshCollider>().enabled = false;
    }
    public void RemoveCoin(GameObject coin)
    {
        coins.Remove(coin);
    }
    private void Update()
    {
        if (GameManager.instance.IsStart && !GameManager.instance.IsFailed && !GameManager.instance.IsWon)
        {
            MoveHorizontal();
            Swipe();
            SwingMovement();
            if (!stopFinish)
                RemoveCoins();

            if (coins.Count < 3 && !stopMovement && stopDiceGate)//dice kismi
            {
                dice.toDice();
                stopDiceGate = false;
                stopMovement = true;
                Invoke("StopCamera", .5f);
            }
            if (coins.Count < 3 && !stopMovement && stopRouletteGate)//rulet kismi
            {
                roulette.PlayRoulette();
                stopRouletteGate = false;
                stopMovement = true;
                Invoke("StopCamera", .5f);
            }

            //finish kismi
            if (stopFinish && !beforeFinish)
            {
                beforeFinish = true;
                totalCoinBeforeFinish = GetCoinCount();
            }
            if (coins.Count < 3 && stopFinish)
            {
                stopFinish = false;
                Invoke("FinishSortCoins", .5f);
            }
        }
    }
    private void FinishSortCoins()
    {
        GameManager.instance.IsWon = true;
        coins[0].GetComponent<BoxCollider>().enabled = false;//player boxcollider kapatiyorum
        AnimationManager.instance.StartIdleAnimation();
        DOTween.To(() => playerMovement.ForwardSpeed, x => playerMovement.ForwardSpeed = x, 0, 1f);

        int totalCoin = totalCoinBeforeFinish + 1;
        FinishCoinCreate.CreateCoin(totalCoin);
    }
    private void StopCamera()
    {
        AnimationManager.instance.StartIdleAnimation();
        DOTween.To(() => playerMovement.ForwardSpeed, x => playerMovement.ForwardSpeed = x, 0, 1f);
    }
    private void RemoveCoins()
    {
        for (int i = 2; i < coins.Count; i++)
        {
            if (!coins[i].GetComponent<AddCoins>().enabled)
            {
                coinCount.UpdateCoinCount();
                coins[i].GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-45, 45), Random.Range(30, 60), 0), ForceMode.Impulse);
                coins.Remove(coins[i]);
            }
        }
    }
    private void RemoveCoinsAtFinish()
    {
        for (int i = 2; i < coins.Count; i++)
        {
            if (!coins[i].GetComponent<AddCoins>().enabled)
            {
                coins.Remove(coins[i]);
            }
        }
    }
    public int GetCoinCount()
    {
        return coins.Count - 2;//root ve player liste basinda oldugu icin -2
    }

    private void SwingMovement()
    {
        for (int i = 1; i < coins.Count; i++)
        {
            prevCoin = coins[i - 1];
            currCoin = coins[i];

            Vector3 newPos;
            newPos.x = prevCoin.transform.localPosition.x;
            newPos.y = 1.2f;// cubes[0].transform.localPosition.y;// root-player
            newPos.z = coins[i].transform.localPosition.z;

            currCoin.transform.localPosition = Vector3.Lerp(currCoin.transform.localPosition, newPos, swingValue);
        }
    }
    private void MoveHorizontal()
    {
        var currentPos = transform.localPosition;
        var dragPos = Vector3.right * inputDrag.x * swipeSpeed * Time.deltaTime;

        if (coins[0].transform.localPosition.x > rightMovementLimitPos)
        {
            coins[0].transform.localPosition = new Vector3(rightMovementLimitPos - .02f, transform.localPosition.y, 0);
        }
        if (coins[0].transform.localPosition.x < leftMovementLimitPos)
        {
            coins[0].transform.localPosition = new Vector3(leftMovementLimitPos + .02f, transform.localPosition.y, 0);
        }
        else
        {
            coins[0].transform.localPosition += dragPos;
        }
    }
    private void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            preMousePos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            var deltaMouse = Input.mousePosition - preMousePos;
            inputDrag = deltaMouse;
            preMousePos = Input.mousePosition;
        }
        else
        {
            inputDrag = Vector3.zero;
        }
    }
}
