using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        // доступ к компоненту MeshRenderer
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"));
        {
            // дотуп к компоненту MeshRenderer обЪекта с тегом "Player"
            MeshRenderer ballRenderer = collision.gameObject.GetComponent<MeshRenderer>();
            // дщступ к Material обЪекта с тегом "Player"
            Material ballMaterial = ballRenderer.material;
            // при коллизии , берет   материал обЪекта с тегом "Player". 
            _meshRenderer.material = ballMaterial;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _meshRenderer.material.color = Color.green;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _meshRenderer.material.color = Color.yellow;
        }
    }
}
