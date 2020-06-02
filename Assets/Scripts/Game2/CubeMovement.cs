using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] float moveTime = 0.5f;
    [SerializeField] float jumpPower = 1f;
    [SerializeField] private float reloadLevelDelay = 1;
    [SerializeField] private GameObject deathEffect;
    
    

    bool allowInput;

    public void SwitchOnCubeGravity()
    {
        Rigidbody rigidbody = FindObjectOfType<Rigidbody>();
        rigidbody.useGravity = true;
    } 
    public void SwitchOffKinematic()
    {
        Rigidbody rigidbody = FindObjectOfType<Rigidbody>();
        rigidbody.isKinematic = false;
    }

    public void Die()
    {
        if (deathEffect != null)
        {
            Vector3 fxPosition = transform.position;
            GameObject newObject = Instantiate(original: deathEffect, fxPosition, Quaternion.identity);
            Destroy(newObject, 2f);
        }
        Destroy(gameObject);
        ScenesLoader.Instance.RestartLevel(reloadLevelDelay);
    }
    
    void Start()
    {
        allowInput = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!allowInput)
        {
            //exit
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //new Vector3(0, 0, 1) = Vector3.forward
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

    //Движение MoveTo в новую позицию newPosition
    void MoveTo(Vector3 newPosition)
    {
        //Debug.DrawRay(newPosition, Vector3.down, Color.green, 2f);
        // Raycast проверяет, есть ли какой-то объект в newPosition в направлении Vector3.dowБ если да, то выполняем движ.
        if (Physics.Raycast(newPosition, Vector3.down, 1f))
        {
            // запретить ещё одно движение во время начатого движения
            allowInput = false;
            // движение через transform и функцию , которая обеспечивает прыжок. ПЕрем. на newPositionб с силой jumpPower
            // один прыжок, за moveTime времени, OnComplete - для повторения движения с каждым нажатием кнопки
            transform.DOJump(newPosition, jumpPower, 1, moveTime).OnComplete(ResetInput);
        }
    }

    void ResetInput()
    {
        allowInput = true;
    }
}
