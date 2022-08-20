using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SnowballPlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float speed;
    [SerializeField] private float maximumSpeed;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _rb.AddForce(Vector3.right * (horizontal * speed));
        _rb.AddForce(Vector3.forward * (vertical * speed));

        if (_rb.velocity.magnitude >= maximumSpeed)
        {
            var velocity = _rb.velocity;
            float brakeSpeed = velocity.magnitude - maximumSpeed; // calculate the speed decrease

            Vector3 normalisedVelocity = velocity.normalized;
            Vector3 brakeVelocity = normalisedVelocity * brakeSpeed; // make the brake Vector3 value

            _rb.AddForce(-brakeVelocity); // apply opposing brake force
        }
    }
}