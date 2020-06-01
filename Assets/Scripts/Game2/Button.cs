using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Button : MonoBehaviour
{
  [SerializeField] float movementUp;
  [SerializeField] float movementDown;
  [SerializeField] private float moveTime;
  [SerializeField] private float delay;

  private Barrier _barrier;
  private Collider _collider;

  private void Awake()
  {
    _collider = GetComponent<Collider>();
  }

  private void Start()
  {
    _barrier = FindObjectOfType<Barrier>();
  }

  public void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      MoveDown();
      _barrier.MoveUp();
    }
  }

  public void OnTriggerExit(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      //transform.DOMoveY(movementUp , moveTime).SetEase(Ease.InCubic);
      StartCoroutine(WaitMoveDown());
      _barrier.MoveDown();
    }
  }

  void MoveDown()
  {
    transform.DOMoveY(movementDown , moveTime).SetEase(Ease.InCubic);
  }

  IEnumerator WaitMoveDown()
  {
    yield return new WaitForSeconds(delay);
    //_barrierMovement.MoveDown();
    transform.DOMoveY(movementUp , moveTime).SetEase(Ease.InCubic);
  }
}
