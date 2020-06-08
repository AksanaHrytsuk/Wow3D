using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int coins;

    [SerializeField] private  float loadLevelDelay = 1f;
    
    [SerializeField]  AudioClip portalMusic;
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
    // колличество камней на сцене на старте игры
    public void AddCoinsCount()
    {
        coins++;
    }
    
    // если все камни собраны, открывается портал в другой уровень
    public void RemoveCoinsCount()                      
    {
        coins--;
        if (coins == 0)
        {
            CreatePortal();
        }
    }

    void CreatePortal()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(1);
        sequence.AppendCallback(() => AudioManager.Instance.PLaySound(portalMusic));
        sequence.AppendCallback(Portal.Instance.NextLevelEffect);
        sequence.AppendCallback(Portal.Instance.OnEnablePortal);
    }
}
