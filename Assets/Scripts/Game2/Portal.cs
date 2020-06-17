using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] private GameObject nextLevelEffect;

    private Collider collider;


    void Start()
    {
        collider = GetComponent<Collider>();
        enabled = false;
        collider.enabled = false;
      
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScenesLoader.Instance.LoadNextScene();
        }
    }

    public void OnEnablePortal()
    {
        collider.enabled = true;
        enabled = true;
    }

    public void NextLevelEffect()
    {
        if (nextLevelEffect != null)
        {
            Vector3 fxPosition = transform.position;
            GameObject newObject = LeanPool.Spawn(nextLevelEffect, fxPosition, Quaternion.identity);
        }
    }
}
