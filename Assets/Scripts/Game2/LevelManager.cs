using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int coins;

    [SerializeField] private  float loadLevelDelay = 1f;
    
   public static LevelManager Instance { get; private set; }

    #region Singltone

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    #endregion

    public void AddCoinsCount()
    {
        coins++;
    }

    public void RemoveCoinsCount()                      
    {
        coins--;
        if (coins == 0)
        {
            Portal.Instance.OnEnablePortal();
            Portal.Instance.CreateEffect();
            Time.timeScale = 0.5f;
            //Invoke(nameof(ScenesLoader.Instance.RestartLevel), loadLevelDelay);
        }
    }
}
