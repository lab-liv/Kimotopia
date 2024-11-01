using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstroMotor : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 moveVector;
    private float speed = 0.7f; //velocidade dos monstros

    private int a; //variavel que comanda quando é para direita e qnd é para esquerda
    private int b; // variavel que conta quantas vezes foi para a direita

    // Use this for initialization
    void Start()
    {

        controller = GetComponent<CharacterController>();

        a = 0;
        b = 0;
    }

    // Update is called once per frame
    void Update()
    {
   
        a++;

        if (a<=50) // fica 20 update aqui
        {
       
                moveVector.x = -2.0f * speed;

        }
        else // fica 20 update aqui
        {
            b++;
            moveVector.x = 2.0f * speed;
            if(b==50) // 20 update atingidos
            {
                b = 0; // comeca dnv
                a = 0; // comeca dnv
            }

        }



        moveVector.y = 0;
        moveVector.z = 0;

        controller.Move(moveVector * Time.deltaTime); // movimentacao do monstro
        moveVector = Vector3.zero;

    }
}
