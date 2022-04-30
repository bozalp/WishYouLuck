using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Fields
    public static GameManager instance;
    private bool isStart, isWon, isFailed;

    #endregion 

    #region Properties
    public bool IsStart
    {
        get
        {
            return isStart;
        }
        set
        {
            isStart = value;
        }
    }
    public bool IsWon
    {
        get
        {
            return isWon;
        }
        set
        {
            isWon = value;
        }
    }
    public bool IsFailed
    {
        get
        {
            return isFailed;
        }
        set
        {
            isFailed = value;
        }
    }
    #endregion

    #region Methods
    private void Singleton()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    private void Awake()
    {
        Singleton();
    }
    #endregion
}
