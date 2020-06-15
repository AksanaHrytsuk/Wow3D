using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BarrierPendulum : MonoBehaviour
{
    [Header("Config parameters")]
    [SerializeField] private float moveTime;
    [SerializeField] private float waitTimeUp;
    [Header("Movement parameters")]
    [SerializeField] private AnimationCurve movementEase1;
    [SerializeField] private AnimationCurve movementEase2;
    
    private CubeMovement _cube;
    private Sequence _sequence;
    Vector3 _moveLeft = new Vector3(0, 0, 120);
    Vector3 _moveRight = new Vector3(0, 0, -120);
    Vector3 _moveCenter = new Vector3(0, 0, 0);
    


    void Start()
    {
        _cube = FindObjectOfType<CubeMovement>();
        
        _sequence = DOTween.Sequence();
        _sequence.Append(transform.DORotate(_moveRight, moveTime).SetEase(movementEase1));
        _sequence.AppendInterval(waitTimeUp);
        _sequence.Append(transform.DORotate(_moveCenter, moveTime).SetEase(movementEase2));
        _sequence.Append(transform.DORotate(_moveLeft, moveTime).SetEase(movementEase1));
        _sequence.AppendInterval(waitTimeUp);
        _sequence.Append(transform.DORotate(_moveCenter, moveTime).SetEase(movementEase2));
        _sequence.SetLoops(-1, LoopType.Restart);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _cube.Die();
        }
    }
}
