using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    
    private new Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
           // rigidbody.AddTorque(Vector3.forward * jumpForce, ForceMode.Impulse);
        }

        float inputX = Input.GetAxis("Horizontal");// влево вправо
        float inputZ = Input.GetAxis("Vertical"); //вперед назад
        
        rigidbody.AddForce(new Vector3(inputX, 0, inputZ) * speed);
    }
}
