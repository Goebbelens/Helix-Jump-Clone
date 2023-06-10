using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Transform Level;
    private Vector3 _previousMousePosition;
    public float RotationVelocity = 1f;


    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            Level.Rotate(0, -delta.x * RotationVelocity, 0);
        }
        _previousMousePosition = Input.mousePosition;
    }
}
