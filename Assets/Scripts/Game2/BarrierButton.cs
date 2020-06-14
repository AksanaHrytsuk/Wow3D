using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierButton : Button
{
    [Header("Components")] [SerializeField]
    private Barrier _barrier;

    public override void ActionOne()
    {
        _barrier.MoveUp();
    }

    public override void ActionTwo()
    {
        _barrier.MoveDown();
    }
    #region LogError

    void Start()
    {
        // вывод сообщения, если ссылка не задана
        if (_barrier == null)
        {
            Debug.LogError("Block is not set");
        }
    }

    #endregion
}
