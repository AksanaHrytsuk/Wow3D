using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Platform : MonoBehaviour
{
    public bool forward;

    public bool back;

    public bool left;

    public bool right;
    public int units;

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
            // Vector3 target = new Vector3(transform.position.x + 0.8f , transform.position.y, transform.forward.z);
            transform.DOMoveX (_targetRight, 1, false);
        }
    }


    // void ChangePosition(PlatformStates newPlatformPosition) 
    // {
    //     movemenPlatform = newPlatformPosition;
    //     
    //     switch (movemenPlatform) 
    //     {
    //         case PlatformStates.Forward:
    //            // _aiDestinationSetter.followPlayer = true;
    //           
    //             break;
    //         case PlatformStates.Back:
    //            // _aiDestinationSetter.followPlayer = false;
    //            
    //             break;
    //         case PlatformStates.Left:
    //         {
    //         }
    //             break;
    //         case PlatformStates.Right:
    //             
    //             break;
    //     } 
    // }

    // void MoveTo(Vector3 newPosition)
    // {
    //     transform.DOMove(newPosition, 1).SetEase(Ease.InBounce);
    // }
}