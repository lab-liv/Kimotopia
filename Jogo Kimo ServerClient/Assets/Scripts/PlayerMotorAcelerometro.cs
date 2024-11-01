using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PlayerMotorAcelerometro : MonoBehaviour
{
    

    //objetos do menino para trocar de cor
    public GameObject playerTY_hand;

    public GameObject playerTY_head;



    private CharacterController controller;
    private Vector3 moveVector;
	private static int speed = 5;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    private float animationDuration = 3.0f;

	public static float x, y, z;

    //---------------------------------------------------
    //------------------ TROCA DE COR -------------------
    //---------------------------------------------------

    //cores do menino
    private static Color cor_Doente = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f); //FF7676FF - vermelho


    private static Color cor_Saudavel = new Color(255f / 255f, 222f / 255f, 173f / 255f);
    //duração da transição de cor
    private static float duration = 1.0F;

    //componentes onde se troca a cor
    private static Renderer hand_Renderer;
    private static Renderer head_Renderer;

    //---------------------------------------------------

    // Use this for initialization
    void Start()
    {


        controller = GetComponent<CharacterController>();

        //busca componentes de cor

         head_Renderer = playerTY_head.GetComponent<Renderer>();
         hand_Renderer = playerTY_hand.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
		//Recebe a velocidade alterado pelo modulo_replica
		if (Server.speed!=0)
			speed = Server.speed;

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
        moveVector.x = Input.acceleration.x * speed; // tcc -> (Input.GetAxis("Horizontal") * speed) * Time.deltaTime;

        //y - up and down
        moveVector.y = verticalVelocity;

        //z - foward and backward
        moveVector.z = speed * 1.3f;


		//Para enviar para o modulo_replica
		x = moveVector.x;
		y = moveVector.y;
		z = moveVector.z;


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


    //---------------------------------------------------
    //------------------ TROCA DE COR -------------------
    //---------------------------------------------------


    public void Cor(bool cor)
    {
        if (cor == true)
        {   //se esta doente, pisca a cor
            //comandos para fazer transição de cores gradualmente
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            playerTY_head.GetComponent<Renderer>().material.color = Color.Lerp(cor_Saudavel, cor_Doente, lerp);
            playerTY_hand.GetComponent<Renderer>().material.color = Color.Lerp(cor_Saudavel, cor_Doente, lerp);
        }
        else
        {   //se esta curado, troca a cor
            TrocaCorPlayerTY(cor_Saudavel);
        }
    }



    //---------------------------------------------------
    //------------------ TROCA DE COR -------------------
    //---------------------------------------------------

    //função para trocar a cor do menino
    static void TrocaCorPlayerTY(Color cor)
    {
        head_Renderer.material.color = cor;
        hand_Renderer.material.color = cor;
    }

}