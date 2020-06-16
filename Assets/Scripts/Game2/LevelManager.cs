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

    [SerializeField] private Text coinText;

    private Portal portal;

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
            Debug.Log("here");
            CreatePortal();
        }
    }

    private void Start()
    {
        portal = FindObjectOfType<Portal>();
        DontDestroyOnLoad(gameObject);
    }

    void CreatePortal()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(1);
        sequence.AppendCallback(() => AudioManager.Instance.PLaySound(portalMusic));
        sequence.AppendCallback(portal.NextLevelEffect);
        sequence.AppendCallback(portal.OnEnablePortal);
    }

    public void UpdateCoinsText()
    {
        coinText.text = "Coins: " + AllCoins;
    }
}
