﻿using System;
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
            MeshRenderer ballRenderer = collision.gameObject.GetComponent<MeshRenderer>();
            Material ballMaterial = ballRenderer.material;
            // при коллизии передаёт материал шара. Того объекта, который сталкивается с кубом
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
