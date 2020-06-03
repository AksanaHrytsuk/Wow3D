using System;
using UnityEngine;
using DG.Tweening;

public class Barrier : MonoBehaviour
{
    [Header("Config parametrs")]
    [SerializeField] float movementUp;
    [SerializeField] float movementDown;
    [SerializeField] private float moveTime;
    [SerializeField] private float waitTimeUp;
    [SerializeField] private float waitTimeDown;

    [Header("DoShakePosition parameters")] [SerializeField]
    private float duration;
    [SerializeField] private float strength;
    [SerializeField] private int vibrato;
    [SerializeField] private float randomness;
        
    private Sequence movementSequence;

    private Collider _collider;
    private CubeMovement _cube;
   
    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void Start()
    {
        _cube = FindObjectOfType<CubeMovement>();
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
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
        
        movementSequence.AppendInterval(waitTimeDown);
        movementSequence.Append(transform.DOShakePosition(duration, strength, vibrato, randomness));
        movementSequence.AppendInterval(waitTimeUp);
        movementSequence.AppendCallback(SwitchOnCollider);
        movementSequence.Append(transform.DOMoveY(movementDown, moveTime));
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
