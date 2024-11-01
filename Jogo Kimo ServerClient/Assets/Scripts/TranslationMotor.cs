using UnityEngine;
using System.Collections;

public class TranslationMotor : MonoBehaviour
{

    public float turnSpeed;


    void Update()
    {

        transform.Rotate(Vector3.down, turnSpeed * Time.deltaTime);

    }
}