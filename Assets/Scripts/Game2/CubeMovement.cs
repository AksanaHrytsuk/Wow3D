using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] private float moveTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Vector3 newPosition = transform.position + new Vector3(0, 0, 1);
            Vector3 newPosition = transform.position + Vector3.forward;
            MoveTo(newPosition);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 newPosition = transform.position + Vector3.back;
            MoveTo(newPosition);
        } 
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 newPosition = transform.position + Vector3.left;
            MoveTo(newPosition);
        } 
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            
            Vector3 newPosition = transform.position + Vector3.right;
            MoveTo(newPosition);
        }
    }

    void MoveTo(Vector3 newPosition)
    {
        transform.DOMove(newPosition, moveTime)
            .SetEase(Ease.OutElastic);
    }
}
