using System;
using UnityEngine;
using DG.Tweening;
using Lean.Pool;

public class PortalBetweenPoints : MonoBehaviour
{
    [Header("Effects")] [SerializeField] private GameObject nextLevelEffect;

    public Transform destinationPoint;
    private Sequence _sequence;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            _sequence = DOTween.Sequence();
            _sequence.AppendCallback(NextPointEffect);
            _sequence.AppendInterval(0.5f);
            _sequence.AppendCallback(() => Teleport(collision));
        }
    }

    void Teleport(Collider collision)
    {
        collision.transform.position = destinationPoint.position;
    }

    private void NextPointEffect()
    {
        if (nextLevelEffect != null)
        {
            Vector3 fxPosition = transform.position;
            GameObject newObject = LeanPool.Spawn(nextLevelEffect, fxPosition, Quaternion.identity);
            //LeanPool.Despawn(newObject, 2f);
        }
    }
}