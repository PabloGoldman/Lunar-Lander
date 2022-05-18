using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float verticalSpeed = 5f;


    [SerializeField] float rollSpeed = 5;

    private Vector3 initialPos;
    private Vector3 initialVelocity;
    private Quaternion initialRot;

    Rigidbody rb;

    public int score = 0;
    public int GetScore() => score;

    private float angleTreshold = 42;

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
        Vector3 aux = new Vector3(0, 0, 0);
        rb.velocity = aux;
        rb.Sleep();

        if (collision.gameObject.tag == "Platform")
        {
            if (!collision.gameObject.GetComponent<Platform>().pressed)
            {
                ResetPlayerPos();
                score++;
                Debug.Log("Ganaste");
            }
        }

        if (Vector3.Angle(transform.up, collision.collider.transform.up) >= angleTreshold)
        {
            ResetPlayerPos();
            Debug.Log("Perdiste");
        }
    }
}
