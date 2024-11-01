using UnityEngine;
using System.Collections;

public class RotationMotor : MonoBehaviour
{
    
    public float turnSpeed;


    void Update()
    {

        transform.Rotate(Vector3.left, turnSpeed * Time.deltaTime);

    }
}