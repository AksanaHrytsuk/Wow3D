using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] private GameObject nextLevelEffect;

    private Collider collider;

    #region Singltone

    public static Portal Instance { get; private set; }

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
    void Start()
    {
        collider = GetComponent<Collider>();
        Instance.enabled = false;
        collider.enabled = false;
        NextLevelEffect();
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
        Portal.Instance.enabled = true;
    }

    public void NextLevelEffect()
    {
        if (nextLevelEffect != null)
        {
            Vector3 fxPosition = transform.position;
            GameObject newObject = Instantiate(original: nextLevelEffect, fxPosition, Quaternion.identity);
            Destroy(newObject, 2f);
        }
    }
}
