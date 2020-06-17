using UnityEngine;
using Lean.Pool;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [Header("Config parameters")]
    
    [Header("Effects")]
    [SerializeField] private GameObject boomEffect;
    
    [Header("Sounds")]
    [SerializeField] private AudioClip magicClip;
    
    [Header("Rotations and movements")]
    [SerializeField] private Vector3 rotationAngel;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            DestroyCoin();
            LevelManager.Instance.UpdateCoinsText();
        }
    }
    
     void CreateEffect()
    {
        if (boomEffect != null)
        {
            Vector3 fxPosition = transform.position;
            GameObject newObject = LeanPool.Spawn(boomEffect, fxPosition, Quaternion.identity);
            //LeanPool.Despawn(newObject, 2f);
        }
    }

    void DestroyCoin()
    {
        AudioManager.Instance.PLaySound(magicClip);
        CreateEffect();
        LevelManager.Instance.AllCoins++;
        LevelManager.Instance.RemoveCoinsCount();
        Destroy(gameObject);
    }

    private void Start()
    {
        LevelManager.Instance.CoinsAmount();
    }

    void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        transform.Rotate(rotationAngel * (Time.deltaTime / 2), Space.World);
    }
}
