using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed, xPosLimit, movementSpeed;

    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * movementSpeed, xPosLimit) - 3f,
                                  transform.position.y, transform.position.z);

        transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime);
    }
}
