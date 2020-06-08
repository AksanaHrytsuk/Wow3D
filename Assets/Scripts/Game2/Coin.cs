using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]  float coinsAmount;
    [SerializeField]  float addCoins;

    [SerializeField] private GameObject boomEffect;
    [SerializeField] private AudioClip magicClip;
    
    [SerializeField] private Vector3 rotationAngel;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            DestroyCoin();
            
        //     AudioManager.Instance.PLaySound(magicClip);
        //     CreateEffect();
        //     coinsAmount += addCoins;
        //     Destroy(gameObject);
        }
    }
    
     void CreateEffect()
    {
        if (boomEffect != null)
        {
            Vector3 fxPosition = transform.position;
            GameObject newObject = Instantiate(original: boomEffect, fxPosition, Quaternion.identity);
            Destroy(newObject, 2f);
        }
    }

    void DestroyCoin()
    {
        AudioManager.Instance.PLaySound(magicClip);
        CreateEffect();
        coinsAmount += addCoins;
        LevelManager.Instance.RemoveCoinsCount();
        Destroy(gameObject);
    }

    private void Start()
    {
        LevelManager.Instance.AddCoinsCount();
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
