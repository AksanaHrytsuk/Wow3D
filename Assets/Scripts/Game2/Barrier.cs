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
    [SerializeField] private float reloadLevelDelay = 1;

    private Sequence movementSequence;

    private Collider _collider;
    private CubeMovement _cube;
   
        
    
    // private static BarrierMovement instans;
    //
    // public static BarrierMovement Instans
    // {
    //     get
    //     {
    //         return instans;
    //     }
    // }

    // Start is called before the first frame update

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    void Start()
    {
        // instans = this;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            _cube = FindObjectOfType<CubeMovement>();
            Destroy(_cube);
            ScenesLoader.Instance.RestartLevel(reloadLevelDelay);
        }
    }

    public void  MoveUp ()
    {
            movementSequence = DOTween.Sequence();
            movementSequence.Append(transform.DOMoveY(movementUp, moveTime)).SetEase(Ease.InExpo);
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
