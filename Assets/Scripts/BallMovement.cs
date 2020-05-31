using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float speed;

    Rigidbody rb;

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            //rb.AddTorque(Vector3.forward * jumpForce, ForceMode.Impulse);
        }

        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(inputX, 0, inputZ) * Speed);
    }
}
