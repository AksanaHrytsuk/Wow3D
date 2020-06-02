using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using DG.Tweening;
public class FallGround : MonoBehaviour
{
    [SerializeField] private float waitTimeDown = 2f;

    public bool fallGround;
    
    private Sequence _sequence;

    private Rigidbody _rigidbody;
    private CubeMovement cube;
    
    public void OnCollisionEnter(Collision other1)
    {
        if (other1.collider.CompareTag("Player") && fallGround)
        {
            cube.SwitchOnCubeGravity();
            cube.SwitchOffKinematic();
            MoveDownGround();
        }
    }

    private void MoveDownGround()
    {
        _sequence = DOTween.Sequence();
        _sequence.AppendInterval(waitTimeDown)
            .Append(transform.DOShakePosition(0.1f, 0.1f, 360))
            .AppendInterval(waitTimeDown)
            .OnComplete(SwitchOnGroundGravity);
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        cube = FindObjectOfType<CubeMovement>();
    }

    private void SwitchOnGroundGravity()
    {
        _rigidbody.useGravity = true;
    }
}
