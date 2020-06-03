using UnityEngine;
using DG.Tweening;

public class Button : MonoBehaviour
{
  [Header("Config parameters")]
  [SerializeField] float movementUp; // движение вверх на 0,1 
  [SerializeField] float movementDown; // движение вверх на 0,1 
  [SerializeField] private float moveTime; // время, за которое кнопка вверх поднимается
  [SerializeField] private float delay; // задержка, перед поднятием кнопки

  [SerializeField] Barrier _barrier;
  
  private bool buttonPressed;

  private void Start()
  {
    // вывод сообщения, если ссылка не задана
    if (_barrier == null)
    {
      Debug.LogError("Block is not set");
    }
  }

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
    // если gameObject c тегом Player сталкивается с button и кнопка нажата, то 
    // вызов методов 
    if (other.CompareTag("Player") && !buttonPressed)
    {
      PressButton();
      MoveDownButton();
      _barrier.MoveUp();
    }
  }

  public void OnTriggerExit(Collider other)
  {
    // если gameObject c тегом Player сталкивается с button и кнопка не нажата, то 
    // вызов методов 
    if (other.CompareTag("Player") && buttonPressed)
    {
      WaitMoveUpButton();
      _barrier.MoveDown();
    }
  }

  void MoveDownButton()
  {
    transform.DOMoveY(movementDown , moveTime).SetEase(Ease.InCubic);
  }

  void WaitMoveUpButton()
  {
    transform.DOMoveY(movementUp , moveTime).SetDelay(delay).SetEase(Ease.InCubic).OnComplete(UnpressButtom);
  }
}
