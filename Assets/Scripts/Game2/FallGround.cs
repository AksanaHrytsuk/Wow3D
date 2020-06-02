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
            MoveDownGround();
            //cube.SwitchOnCubeGravity();
            //cube.SwitchOffKinematic();
        }
    }

    private void MoveDownGround()
    {
        _sequence = DOTween.Sequence();
        _sequence.AppendInterval(waitTimeDown)
            .Append(transform.DOShakePosition(0.3f, 0.5f, 360))
            .AppendCallback(SwitchOnGroundGravity)
            .AppendCallback(cube.SwitchOnCubeGravity)
            .AppendCallback(cube.SwitchOffKinematic);
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
