using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RouletteBall : MonoBehaviour
{
    [SerializeField]
    private Roulette roulette;
    [HideInInspector]
    public bool showResult, isRed;

    private void OnTriggerStay(Collider other)
    {
        if (roulette.BallStoped && !showResult)
        {
            if (other.gameObject.name == "R")
                isRed = true;
            else
                isRed = false;

            showResult = true;
            transform.DOMove(other.transform.position, .2f);
        }
    }
}
