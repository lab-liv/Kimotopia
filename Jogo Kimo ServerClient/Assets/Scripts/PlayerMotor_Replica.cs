using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PlayerMotor_Replica : MonoBehaviour
{


	//objetos do menino para trocar de cor
	public GameObject playerTY_hand;

	public GameObject playerTY_head;



	private CharacterController controller;
	public static Vector3 moveVector;
	private float speed = 5.0f;
	private float verticalVelocity = 0.0f;
	private float gravity = 12.0f;

	private float animationDuration = 3.0f;

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

	public static GameObject esfera;
	public static Vector3 posicao;
	//---------------------------------------------------

	// Use this for initialization
	void Start()
	{


		controller = GetComponent<CharacterController>();
		esfera = GameObject.Find ("Sphere");

	}

	public static void Posicao(float px, float py, float pz)
	{


//		Debug.Log(px+" - "+py+" - "+pz);
		posicao = new Vector3 (px, py, pz);
		esfera.transform.position = posicao;

	}

	// Update is called once per frame
	void Update()
	{



			//Corre infinitamente
			controller.Move(Vector3.forward * speed * Time.deltaTime);
			//return;

		//moveVector.x = Server.x;

		//y - up and down
		//moveVector.y = Server.y;

		//z - foward and backward
		//moveVector.z = Server.z;

		//controller.Move(moveVector * Time.deltaTime);


	}

}