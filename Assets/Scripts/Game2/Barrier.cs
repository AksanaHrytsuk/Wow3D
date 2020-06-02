using System;
using UnityEngine;
using DG.Tweening;

public class Barrier : MonoBehaviour
{
    [SerializeField] float movementUp;
    [SerializeField] float movementDown;
    [SerializeField] private float moveTime;
    [SerializeField] private float waitTimeUp;
    [SerializeField] private float waitTimeDown;

    private Sequence movementSequence;

    private Collider _collider;
    private CubeMovement _cube;
   
    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            _cube = FindObjectOfType<CubeMovement>();
            _cube.Die();
        }
    }

    public void  MoveUp ()
    {
            movementSequence = DOTween.Sequence();
            movementSequence.Append(transform.DOMoveY(movementUp, moveTime)).SetEase(Ease.InExpo);
            SwitchOffCollider();
    }

    public void MoveDown()
    {
        movementSequence = DOTween.Sequence();
        movementSequence.AppendInterval(waitTimeDown)

            .Append(transform.DOShakePosition(0.3f, 0.3f, 360))
            .AppendInterval(waitTimeUp)
            .AppendCallback(SwitchOnCollider)
            .Append(transform.DOMoveY(movementDown, moveTime));
    }

    private void SwitchOnCollider()
    {
        _collider.enabled = true;
    }

    private void SwitchOffCollider()
    {
        _collider.enabled = false;  
    }
}
