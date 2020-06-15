using System;
using UnityEngine;
using DG.Tweening;

public class CubeMovement : MonoBehaviour
{
    [Header("Config parametrs")]
    [SerializeField] float moveTime;
    [SerializeField] float jumpPower;
    [SerializeField] private float reloadLevelDelay = 1;
    
    [Header("Effects")]
    [SerializeField] private GameObject deathEffect;

    [Header("Sounds")] [SerializeField] private AudioClip deathSound;
    
    private Rigidbody rigidbody;
    private Barrier _barrier;
    
    bool allowInput;

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Die"))
        {
            Die();
        }
    }

    public void SwitchOnCubeGravity()
    {
        rigidbody.isKinematic = false;
        rigidbody.useGravity = true;
    }
    
    public void
        SwitchOnCubeKinematic()
    {
        rigidbody.isKinematic = true;
        rigidbody.useGravity = true;
    }

    public void Die()
    {
        CreateEffect();
        AudioManager.Instance.PLaySound(deathSound);
        Destroy(gameObject);
        ScenesLoader.Instance.RestartLevel(reloadLevelDelay);
    }

    public void CreateEffect()
    {
        if (deathEffect != null)
        {
            Vector3 fxPosition = transform.position;
            GameObject newObject = Instantiate(original: deathEffect, fxPosition, Quaternion.identity);
            Destroy(newObject, 2f);
        }
    }

    private void Awake()
    {
        _barrier = FindObjectOfType<Barrier>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        allowInput = true;
    }

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
            MoveTo(newPosition, Vector3.forward);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 newPosition = transform.position + Vector3.back;
            MoveTo(newPosition, Vector3.back);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 newPosition = transform.position + Vector3.left;
            MoveTo(newPosition,Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 newPosition = transform.position + Vector3.right;
            MoveTo(newPosition, Vector3.right);
        }
    }

    public void MoveForward()
    {
        if (!allowInput) { return; }
        Vector3 newPosition = transform.position + Vector3.forward;
        MoveTo(newPosition, Vector3.forward);
    }

    public void MoveBack()
    {
        if (!allowInput) { return; }
        Vector3 newPosition = transform.position + Vector3.back;
        MoveTo(newPosition, Vector3.back);
    }

    public void MoveLeft()
    {
        if (!allowInput) { return; }
        Vector3 newPosition = transform.position + Vector3.left;
        MoveTo(newPosition, Vector3.left);
    }

    public void MoveRight()
    {
        if (!allowInput) { return; }
        Vector3 newPosition = transform.position + Vector3.right;
        MoveTo(newPosition, Vector3.right);
    }


    //Движение MoveTo в новую позицию newPosition
    void MoveTo(Vector3 newPosition , Vector3 direction)
    {
        LayerMask layerMask = LayerMask.GetMask($"Barrier");

        //Debug.DrawRay(newPosition, Vector3.down, Color.green, 2f);
        // Raycast проверяет, есть ли какой-то объект в newPosition в направлении Vector3.dowБ если да, то выполняем движ.
        if (Physics.Raycast(newPosition, Vector3.down, 1f) && !Physics.Raycast(transform.position, direction: direction, maxDistance:1, layerMask))
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
