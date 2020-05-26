using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] private float moveTime = 0.5f;

    [SerializeField] private float jumpPower = 0.5f;

    private bool allowInput;
    // Start is called before the first frame update
    void Start()
    {
        allowInput = true;
    }

    void Update()
    {
        if (!allowInput)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Vector3 newPosition = transform.position + new Vector3(0, 0, 1); движение по Z(синяя стрелка)
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
        // Debug.DrawRay(newPosition,Vector3.down,Color.green, 2f); показать луч
        if (Physics.Raycast(newPosition, Vector3.down))
        
        //transform.DOMove(newPosition, moveTime) .SetEase(Ease.OutElastic); движение без прыжков
        allowInput = false;
        transform.DOJump(newPosition, jumpPower, 1, moveTime).OnComplete(ResetInput);
        
        // Invoke(nameof(ResetInput), moveTime);
           
    }

    void ResetInput()
    {
        allowInput = true;
    }
}
