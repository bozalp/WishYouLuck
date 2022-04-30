using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    #region Fields
    public static AnimationManager instance;

    private Animator animator;
    [SerializeField]
    private GameObject player;
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
        animator = player.GetComponent<Animator>();
    }

    public void StartRunAnimation() => animator.SetTrigger("Run");
    public void StartVictoryAnimation() => animator.SetTrigger("Dance");

    #endregion
}
