using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("Amount")]
    [SerializeField] private int coins;

    [Header("Sounds")]
    [SerializeField]  AudioClip portalMusic;
    
    [Header("UI Elements")]
    [SerializeField] private Text coinText;

    private Portal _portal;

    protected internal int AllCoins { get; set; } = 0;

    #region Singltone

    public static LevelManager Instance { get; private set; }

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
    public void CoinsAmount()
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

    private void Start()
    {
        _portal = FindObjectOfType<Portal>();
       // DontDestroyOnLoad(gameObject);
    }

    void CreatePortal()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(1);
        sequence.AppendCallback(() => AudioManager.Instance.PLaySound(portalMusic));
        sequence.AppendCallback(_portal.NextLevelEffect);
        sequence.AppendCallback(_portal.OnEnablePortal);
    }

    public void UpdateCoinsText()
    {
        coinText.text = "Coins: " + AllCoins;
    }
}
