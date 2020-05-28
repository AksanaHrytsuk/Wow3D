using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    [SerializeField] float maxYValue = 0.2f;
    [SerializeField] float moveTime = 1;
    [SerializeField] float waitTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(Movement());
        Sequence movementSequence = DOTween.Sequence();
        movementSequence.AppendInterval(waitTime);
        movementSequence.Append(transform.DOMoveY(maxYValue, moveTime));
        movementSequence.AppendInterval(waitTime);
        movementSequence.Append(transform.DOMoveY(0, moveTime));
        movementSequence.SetLoops(-1);
        

        // Sequence movementSequence = DOTween.Sequence();
        // movementSequence.AppendInterval(waitTime / 2)
        //     .Append((transform.DOMoveY(maxYValue, moveTime))
        //         .AppendInterval(waitTime)
        //         .Append(transform.DOMoveY(0, moveTime))
        //         .SetLoops(-1, LoopType.Yoyo);

    }
    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        
    }

    IEnumerator Movement()
    {
        while(true)
        {
            transform.DOMoveY(maxYValue, moveTime);
            yield return new WaitForSeconds(moveTime + waitTime);
            transform.DOMoveY(0, moveTime);
            yield return new WaitForSeconds(moveTime + waitTime);
        }
    }
    
    

}
