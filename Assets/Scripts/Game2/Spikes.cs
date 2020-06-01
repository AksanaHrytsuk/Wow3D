using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Spikes : MonoBehaviour
{
    [SerializeField] float maxYValue = 0.2f;
    [SerializeField] float moveTime = 1;
    [SerializeField] float waitTime = 1;
    
    void Start()
    {
        // // Инициализация Sequence с заданным именем movementSequence. Принадлежит библиотеке DG.Tweening;
        // Sequence movementSequence = DOTween.Sequence();
        //
        // // Добавить интервал - время ожидание - waitTime
        // movementSequence.AppendInterval(waitTime);
        //
        // // Добавляем действие в последовательности - подняться вверх
        // movementSequence.Append(transform.DOMoveY(maxYValue, moveTime)).SetEase(Ease.InExpo);
        //
        // movementSequence.AppendInterval(waitTime);
        //
        // // Добавляем действие в последовательности - опуститься вниз
        // movementSequence.Append(transform.DOMoveY(0, moveTime));
        //
        // // для бесконечного цикла 
        // movementSequence.SetLoops(-1, LoopType.Yoyo);
        

        Sequence movementSequence = DOTween.Sequence();
        movementSequence.AppendInterval(waitTime/2)
            .Append(transform.DOMoveY(maxYValue, moveTime).SetEase(Ease.InExpo))
            .AppendInterval(waitTime/2)
            .SetLoops(-1, LoopType.Yoyo);

    }
    
    private void OnTriggerEnter(Collider other)
    {
      
            CubeMovement cube = other.GetComponent<CubeMovement>();
            cube.Die();
    }

    IEnumerator Movement()
    {
        while(true)
        {
            // поднятие вверх на maxYValue 
            transform.DOMoveY(maxYValue, moveTime);
            // ожидает вверху moveTime + waitTime
            yield return new WaitForSeconds(moveTime + waitTime);
            // двигается вниз
            transform.DOMoveY(0, moveTime);
            yield return new WaitForSeconds(moveTime + waitTime);
        }
    }
    
    

}
