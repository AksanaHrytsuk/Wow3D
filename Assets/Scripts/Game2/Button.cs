using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Button : MonoBehaviour
{
  [SerializeField] float movementUp;
  [SerializeField] float movementDown;
  [SerializeField] private float moveTime;
  [SerializeField] private float delay;

  public Barrier _barrier;
  
  private bool buttonPressed;

  void PressButton()
  {
    buttonPressed = true;
  }

  void UnpressButtom()
  {
    buttonPressed = false;
  }
 
  public void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player") && !buttonPressed)
    {
      PressButton();
      MoveDownButton();
      _barrier.MoveUp();
    }
  }

  public void OnTriggerExit(Collider other)
  {
    if (other.CompareTag("Player") && buttonPressed)
    {
      StartCoroutine(WaitMoveUpButton());
      _barrier.MoveDown();
    }
  }

  void MoveDownButton()
  {
    transform.DOMoveY(movementDown , moveTime).SetEase(Ease.InCubic);
  }

  IEnumerator WaitMoveUpButton()
  {
    yield return new WaitForSeconds(delay);
    transform.DOMoveY(movementUp , moveTime).SetEase(Ease.InCubic).OnComplete(UnpressButtom);
    
  }
}
