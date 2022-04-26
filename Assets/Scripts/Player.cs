using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    //PREGUNTAR COMO COLISIONAR CON LOS HIJOS
    //COMO HACER QUE SI SUPERA LOS 90 GRADOS EN Z, VUELVA A 90
    //Como frenar la aceleracion

    // Start is called before the first frame update

    [SerializeField] float verticalSpeed = 5f;

    [SerializeField] float rollSpeed = 5;

    [SerializeField] LayerMask terrainLayer;

    private Vector3 initialPos;
    private Vector3 initialVelocity;
    private Quaternion initialRot;

    Rigidbody rb;

    private int score = 0;
    public int GetScore() => score;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        initialPos = transform.position;
        initialRot = transform.rotation;
        initialVelocity = rb.velocity;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (rb.IsSleeping())
        {
            rb.WakeUp();
        }

        Movement();
    }
    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 0.1f, Color.yellow);

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetPlayerPos();
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
        rb.velocity = initialVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down) * 0.1f, terrainLayer))
        {
            Debug.Log("Perdiste");
        }

        Vector3 aux = new Vector3(0, 0, 0);
        rb.velocity = aux;
        rb.Sleep();

        if (collision.gameObject.tag == "Platform")
        {
            ResetPlayerPos();
            score++;
            Debug.Log("Ganaste");
        }
    }
}
