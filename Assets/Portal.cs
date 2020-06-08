using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject nextLevelEffect;

    private Collider collider;

    public static Portal Instance { get; private set; }

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
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        Instance.enabled = false;
        collider.enabled = false;
        CreateEffect();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScenesLoader.Instance.LoadNextScene();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnablePortal()
    {
        collider.enabled = true;
        Portal.Instance.enabled = true;
    }

    public void CreateEffect()
    {
        if (nextLevelEffect != null)
        {
            Vector3 fxPosition = transform.position;
            GameObject newObject = Instantiate(original: nextLevelEffect, fxPosition, Quaternion.identity);
            Destroy(newObject, 2f);
        }
    }
}
