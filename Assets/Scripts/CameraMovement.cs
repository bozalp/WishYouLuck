using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject player, cineCam1, cineCam2;
    [HideInInspector]
    public bool cameraZoom;

    private void Update()
    {
        if(cameraZoom)
        {
            cineCam1.SetActive(false);
            cineCam2.SetActive(true);
            cameraZoom = false;
        }
    }
}
