using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Platform : MonoBehaviour
{
    [Header("Positions")]
    [SerializeField] bool forward;

    [SerializeField] bool back;

    [SerializeField] bool left;

    [SerializeField] bool right;
    
    [Header("Distance")]
    [SerializeField] int units;

    private float _targetRight;
    private float _targetLeft;
    private float _targetForward;
    private float _targetBack;

    private void Start()
    {
        // сохранить состояние
        _targetRight = transform.position.x + units;
        _targetLeft = transform.position.x - units;
        _targetForward = transform.position.z + units;
        _targetBack = transform.position.z - units;
    }

    public void Move()
    {
        if (forward)
        {
            transform.DOMoveZ(_targetForward, 1, false);
        }

        if (back)
        {
            transform.DOMoveZ(_targetBack, 1, false);
        }

        if (left)
        {
            transform.DOMoveX(_targetLeft, 1, false);
        }

        if (right)
        {
            transform.DOMoveX (_targetRight, 1, false);
        }
    }
}