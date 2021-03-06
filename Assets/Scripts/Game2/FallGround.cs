﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Security.AccessControl;
using UnityEngine;
using DG.Tweening;
public class FallGround : MonoBehaviour
{
    [Header("Config parameters")]
    [SerializeField] private float waitTimeDown ;
    [SerializeField] float movementDown; 
    [SerializeField] float movementUp; 

    public bool fallGround;
    
    private Sequence _sequence;

    private Rigidbody _rigidbody;
    private CubeMovement cube;
    
    public void OnCollisionEnter(Collision other1)
    {
        if (other1.collider.CompareTag("Player") && fallGround)
        {
            MoveDownGround();
        }
    }

    private void MoveDownGround()
    {
        _sequence = DOTween.Sequence();
        _sequence.AppendCallback(IsKinematic)
            .AppendInterval(waitTimeDown)
            .AppendCallback(cube.SwitchOnCubeKinematic)
            .Append(transform.DOShakePosition(0.5f, 0.1f, 360))
            .Append(transform.DOMoveY(movementDown, 0.5f))
            .AppendCallback(cube.SwitchOnCubeGravity)
            .AppendInterval(waitTimeDown)
            .Append(transform.DOMoveY(movementUp, 0.5f))
            .AppendInterval(waitTimeDown);
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        cube = FindObjectOfType<CubeMovement>();
    }

    private void IsKinematic()
    {
            _rigidbody.isKinematic = true;
            _rigidbody.detectCollisions = true;
    }
}
