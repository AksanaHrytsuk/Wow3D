using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullPlatformButton : MonoBehaviour
{
    public Platform _platform;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _platform.Move();
        }
    }
}
