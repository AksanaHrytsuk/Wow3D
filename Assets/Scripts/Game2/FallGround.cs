using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FallGround : MonoBehaviour
{
    [SerializeField] private float waitTimeDown = 5f;

    public bool fallGround;

    public FallGround dropGround;
    
    private Sequence _sequence;

    private Rigidbody _rigidbody;
    private CubeMovement cube;
    
    // Start is called before the first frame update
    void Start()
    {
        // _sequence = DOTween.Sequence();
        // _sequence.AppendInterval(waitTimeDown)
        //     .Append(transform.DOShakePosition(0.3f, 0.3f, 360));
    }

    public void OnCollisionEnter(Collision other1)
    {
        if (other1.collider.CompareTag("Player") && fallGround)
        {
            Debug.Log("here");
            SwitchOnGroundGravity();
            cube.SwitchOnCubeGravity();
        }
    }

    private void Awake()
    {
        _rigidbody = FindObjectOfType<Rigidbody>();
        cube = FindObjectOfType<CubeMovement>();
    }

    private void SwitchOnGroundGravity()
    {
        _rigidbody.useGravity = true;
    }
}
