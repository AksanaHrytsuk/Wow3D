using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]  float coinsAmount;
    [SerializeField]  float addCoins;

    [SerializeField] private GameObject boomEffect;
    
    [SerializeField] private Vector3 rotationAngel;

    private CubeMovement cube;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            createEffect();
            coinsAmount += addCoins;
            Destroy(gameObject);
        }
    }
    
     void createEffect()
    {
        if (boomEffect != null)
        {
            Vector3 fxPosition = transform.position;
            GameObject newObject = Instantiate(original: boomEffect, fxPosition, Quaternion.identity);
            Destroy(newObject, 2f);
        }
    }

    private void Awake()
    { 
        cube = FindObjectOfType<CubeMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationAngel * Time.deltaTime, Space.World);
    }
}
