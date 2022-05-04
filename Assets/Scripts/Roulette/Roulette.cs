using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Roulette : MonoBehaviour
{
    [SerializeField]
    private GameObject rulletUp, ballPlatform, ball;
    private bool startRulletGame, rouletteStoped, ballStoped;
    private float rotateSpeed;
    private Sequence sequence;
    public bool BallStoped
    {
        get
        {
            return ballStoped;
        }
    }
    public void PlayRoulette()
    {
        startRulletGame = true;
        rotateSpeed = Random.Range(500, 1000);
    }
    private void Update()
    {
        if(startRulletGame && rotateSpeed > 0)
        {
            rulletUp.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
            ballPlatform.transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
            rotateSpeed -= 100 * Time.deltaTime;
        }
        if (startRulletGame && rotateSpeed < 50 && !rouletteStoped)
        {
            rouletteStoped = true;
            startRulletGame = false;            
        }
        if(rouletteStoped && !ballStoped)
        {
            ballStoped = true;
            Invoke("StopTheBallMovement", .2f);
            Vector3 targetPos = new Vector3(rulletUp.transform.position.x, rulletUp.transform.position.y + 1, rulletUp.transform.position.z);
           sequence.Append(ball.transform.DOMove(targetPos, 2f));
            
        }
    }
    private void StopTheBallMovement()
    {
        DOTween.Kill(sequence);
    }
}
