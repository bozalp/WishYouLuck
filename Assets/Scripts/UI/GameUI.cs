using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject tapToStartPanel;

    public void LevelStart()
    {
        GameManager.instance.IsStart = true;
        AnimationManager.instance.StartRunAnimation();
        tapToStartPanel.SetActive(false);
    }

}
