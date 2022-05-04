using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject tapToStartPanel, winPanel;

    public void LevelStart()
    {
        GameManager.instance.IsStart = true;
        AnimationManager.instance.StartRunAnimation();
        tapToStartPanel.SetActive(false);
    }
    public void ShowWinPanel()
    {
        GameManager.instance.IsWon = true;
        winPanel.SetActive(true);
    }
    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
