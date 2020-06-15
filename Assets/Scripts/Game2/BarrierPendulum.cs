using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BarrierPendulum : MonoBehaviour
{
    [Header("Components")] private CubeMovement _cube;

    private Sequence _sequence;
    
    void Start()
    {
        _cube = FindObjectOfType<CubeMovement>();
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            _cube.Die();
        }
    }

    void BarrierPendulumMovement()
    {
        _sequence = DOTween.Sequence();
        
    }
}
