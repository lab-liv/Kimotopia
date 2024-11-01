using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PlayerMotor2 : MonoBehaviour
{





    private CharacterController controller;
    private Vector3 moveVector;
    private float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    private float animationDuration = 3.0f;






    //---------------------------------------------------

    // Use this for initialization
    void Start()
    {


        controller = GetComponent<CharacterController>();



    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time < animationDuration)
        {

            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }


        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {

            verticalVelocity = -0.5f;

        }
        else
        {

            verticalVelocity -= gravity * Time.deltaTime;
        }



        //x - left and right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed; // tcc -> (Input.GetAxis("Horizontal") * speed) * Time.deltaTime;

        //y - up and down
        moveVector.y = verticalVelocity;

        //z - foward and backward
        moveVector.z = speed;



        controller.Move(moveVector * Time.deltaTime);





        ////////////////////// tcc bluetooth ///////////////////////////
        /*
        //pega valores dos botões do controle
        float v = (Input.GetAxis("Vertical") * speed) * Time.deltaTime;
        float h = (Input.GetAxis("Horizontal") * speed) * Time.deltaTime;
        //movimenta o menino
        transform.Translate(v * Vector3.forward + h * Vector3.right);
        */
    }



}