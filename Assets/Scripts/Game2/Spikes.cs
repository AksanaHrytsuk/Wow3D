using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;
public class Spikes : MonoBehaviour
{
    [SerializeField] private float moveTime = 1;

    [SerializeField] private float waitTime = 1;

    [SerializeField] private float maxYValue = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator Movement()
    {
        while (true)
        {
            transform.DOMoveY(maxYValue, moveTime);
            yield return new WaitForSeconds(moveTime + waitTime);
            transform.DOMoveY(0, moveTime);
            yield return new WaitForSeconds(moveTime + waitTime);
        }
    }
}
