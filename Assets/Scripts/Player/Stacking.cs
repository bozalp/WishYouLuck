using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacking : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> cubes;
    [SerializeField]
    private float swingValue = .3f;
    [SerializeField]
    private float swipeSpeed, rightMovementLimitPos, leftMovementLimitPos, forwardSpeed = 8, coinForwardPosition;

    private GameObject currCoin, prevCoin;
    private Vector3 inputDrag, preMousePos;

    public void AddCube(GameObject collectedCoin)
    {
        collectedCoin.transform.localEulerAngles = new Vector3(Random.Range(0,360), -90, 90);
        float tempForwardPosition = coinForwardPosition;
        cubes.Add(collectedCoin);
        collectedCoin.transform.parent = gameObject.transform;
        collectedCoin.transform.localPosition = new Vector3(cubes[cubes.Count - 2].transform.localPosition.x, 5,
        cubes[cubes.Count - 2].transform.localPosition.z + coinForwardPosition);

    }
    private void Update()
    {
        MoveHorizontal();
        Swipe();
        SwingMovement();
    }

    private void SwingMovement()
    {
        for (int i = 1; i < cubes.Count; i++)
        {
            prevCoin = cubes[i - 1];
            currCoin = cubes[i];

            Vector3 newPos;
            newPos.x = prevCoin.transform.localPosition.x;
            newPos.y = 1;// cubes[0].transform.localPosition.y;// root-player
            newPos.z = cubes[i].transform.localPosition.z;

            currCoin.transform.localPosition = Vector3.Lerp(currCoin.transform.localPosition, newPos, swingValue);
        }
    }
    private void MoveHorizontal()
    {
        var currentPos = transform.localPosition;
        var dragPos = Vector3.right * inputDrag.x * swipeSpeed * Time.deltaTime;

        if (cubes[0].transform.localPosition.x > rightMovementLimitPos)
        {
            cubes[0].transform.localPosition = new Vector3(rightMovementLimitPos - .02f, transform.localPosition.y, 0);
        }
        if (cubes[0].transform.localPosition.x < leftMovementLimitPos)
        {
            cubes[0].transform.localPosition = new Vector3(leftMovementLimitPos + .02f, transform.localPosition.y, 0);
        }
        else
        {
            cubes[0].transform.localPosition += dragPos;
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
