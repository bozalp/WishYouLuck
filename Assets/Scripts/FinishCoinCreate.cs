using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinishCoinCreate : MonoBehaviour
{
    [SerializeField]
    private GameObject[] coins;
    [SerializeField]
    private GameObject[] coinPositions = new GameObject[5];
    [SerializeField]
    private float coinHeight = .25f;
    private int index, positionCounter;
    private GameObject player;
    private CameraMovement camera;
    private GameUI gameUI;
    private void Start()
    {
        DOTween.Init();
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        gameUI = GameObject.FindObjectOfType<GameUI>();
        camera = Camera.main.GetComponent<CameraMovement>();
    }

    public void CreateCoin(int totalCoin)
    {
        while (totalCoin > 0)
        {
            if (index > 4)
            {
                index = 0;
                positionCounter++;
            }
            GameObject coin = Instantiate(coins[Random.Range(0, coins.Length)], transform);
            coin.GetComponent<MeshCollider>().enabled = false;
            coin.GetComponent<AddCoins>().enabled = false;
            coin.transform.parent = coinPositions[index].transform;
            coin.transform.position = new Vector3(coinPositions[index].transform.position.x, positionCounter * coinHeight, coinPositions[index].transform.position.z);
            totalCoin--;
            index++;
        }
        player.transform.DORotate(new Vector3(0, 180, 0), 1f).OnComplete(() =>
            {
                AnimationManager.instance.StartVictoryAnimation();
                camera.cameraZoom = true;
                Invoke("ShowWinPanel", 1f);
            });

    }
    private void ShowWinPanel()
    {
        gameUI.ShowWinPanel();
    }
}
