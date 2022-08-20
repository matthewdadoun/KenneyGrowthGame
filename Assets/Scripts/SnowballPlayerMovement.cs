using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballPlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float movementSpeed;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _rb.AddForce(Vector3.right * (horizontal * movementSpeed));
        _rb.AddForce(Vector3.forward * (vertical * movementSpeed));

        if (_rb.velocity.magnitude >= movementSpeed)
        {
            var velocity = _rb.velocity;
            float brakeSpeed = velocity.magnitude - movementSpeed; // calculate the speed decrease

            Vector3 normalisedVelocity = velocity.normalized;
            Vector3 brakeVelocity = normalisedVelocity * brakeSpeed; // make the brake Vector3 value

            _rb.AddForce(-brakeVelocity); // apply opposing brake force
        }
    }
}