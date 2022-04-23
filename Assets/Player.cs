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
        GetInput();
    }

    private void GetInput()
    {

    }

    private void Movement()
    {
        rb.AddRelativeForce(Vector3.up * verticalSpeed * Input.GetAxisRaw("Up")); //espacio

        rb.AddRelativeTorque(Vector3.right * rollSpeed * Input.GetAxisRaw("Vertical")); // W

        rb.AddRelativeTorque(Vector3.forward * rollSpeed * Input.GetAxisRaw("Roll")); // Q,E

        if (rb.rotation.x < -90)
        {
            Vector3 aux = new Vector3(-90, rb.rotation.y, rb.rotation.z);
            rb.rotation = Quaternion.Euler(aux);
        }
    }

    public void ResetPlayerPos()
    {
        transform.position = initialPos;
        transform.rotation = initialRot;
    }
}
