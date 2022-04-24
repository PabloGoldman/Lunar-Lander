using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float forwardSpeed = 25f;
    [SerializeField] float verticalSpeed = 5f;

    [SerializeField] float rollSpeed = 5, rollAcceleration = 3.5f;

    private Vector3 initialPos;
    private Quaternion initialRot;

    Rigidbody rb;

    Vector3 maxAcceleration = new Vector3(5, 5, 5);

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        initialPos = transform.position;
        initialRot = transform.rotation;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Movement();
    }

    void Update()
    {
        if (rb.velocity.x > maxAcceleration.x)
        {
            rb.velocity = new Vector3(5,0,0);
        }

        if (rb.velocity.y > maxAcceleration.y)
        {
            rb.velocity = new Vector3(0, 5, 0);
        }

        if (rb.velocity.z > maxAcceleration.z)
        {
            rb.velocity = new Vector3(0, 0, 5);
        }
    }

    private void Movement()
    {
        rb.AddRelativeForce(Vector3.up * verticalSpeed * Input.GetAxisRaw("Up"), ForceMode.Force); //espacio

        rb.AddRelativeTorque(Vector3.right * rollSpeed * Input.GetAxisRaw("Vertical"), ForceMode.Force); // W

        rb.AddRelativeTorque(Vector3.forward * rollSpeed * Input.GetAxisRaw("Roll"), ForceMode.Force); // Q,E
    }

    public void ResetPlayerPos()
    {
        transform.position = initialPos;
        transform.rotation = initialRot;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log("Ganaste");
        }
    }

}
