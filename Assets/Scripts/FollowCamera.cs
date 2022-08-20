using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private Vector3 offset;
    
    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = targetObject.transform.position + offset;
    }
}