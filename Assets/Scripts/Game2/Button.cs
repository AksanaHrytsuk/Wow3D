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
  private bool buttonPressed = false;
  private Collider _collider;

  void PressButton()
  {
    buttonPressed = true;
  }

  void UnpressButtom()
  {
    buttonPressed = false;
  }
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
    if (other.CompareTag("Player") && !buttonPressed)
    {
      PressButton();
      MoveDown();
      _barrier.MoveUp();
    }
  }

  public void OnTriggerExit(Collider other)
  {
    if (other.CompareTag("Player") && buttonPressed)
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
    transform.DOMoveY(movementUp , moveTime).SetEase(Ease.InCubic).OnComplete(UnpressButtom);
    
  }
}
