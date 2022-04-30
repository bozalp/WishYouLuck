using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float forwardSpeed = 8;
    void Update()
    {
        if(GameManager.instance.IsStart && !GameManager.instance.IsWon && !GameManager.instance.IsFailed)
            MoveForward();
    }
    private void MoveForward()
    {
        transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
    }
}
