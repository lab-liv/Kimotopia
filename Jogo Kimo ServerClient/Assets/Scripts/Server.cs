using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEditor;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class Server : NetworkBehaviour {

    public static Text teste2;


	public static GameObject modulo_game;
	public static GameObject modulo_espera;
	public static GameObject modulo_aplicador;

	//public GameObject AplicadorObj;
	//public GameObject ReplicaObj;

	public static int v1 =0;
	public static int v2 =0;
	public static int v3 =0;
	public static int v4 =0;
	public static int v5 =0;
	public static int v6 =0;
	public static int v7 =0;


	public static int speed = 0;



	public static GameObject Serverprefab;

	public GameObject Rede;

	public static Server servidor;




	public static string nome;
	public static string idade;
	public static string pontuacao;




	[SyncVar]
	public int teste_valor;

	private GameController script;


	public void Start()
	{
		modulo_aplicador = GameObject.Find ("Aplicador");

		servidor = new GameObject ().AddComponent<Server> ();


	}


	[ClientRpc]
	public void RpcIniciar(string valor1, string valor2, string valor3, string valor4, string valor5, string valor6, string valor7)
	{
		

		AtivaGame.modulo_game.SetActive(true);
		modulo_espera = GameObject.Find ("Espera");
		modulo_espera.SetActive (false);

		v1 = int.Parse(valor1);
		v2 = int.Parse(valor2);
		v3 = int.Parse(valor3);
		v4 = int.Parse(valor4);
		v5 = int.Parse(valor5);
		v6 = int.Parse(valor6);
		v7 = int.Parse(valor7);
	

	}

	[ClientRpc]
	public void RpcVelocidade(int vel)
	{
		
		speed = vel;
	}



	[ClientRpc]
	public void RpcFinalizar()
	{
		NetworkManager.singleton.ServerChangeScene("Modulo_fim");
		//modulo_aplicador.SetActive (true);

	}


	//Iniciar
	public void TaskOnClick()
	{
		RpcIniciar (Inputs.valor1, Inputs.valor2, Inputs.valor3, Inputs.valor4, Inputs.valor5, Inputs.valor6, Inputs.valor7);
		AtivaReplica.modulo_replica.SetActive(true);
		modulo_aplicador.SetActive(false);


	}

	//Finalizar
	public void TaskOnClick2()
	{
		RpcFinalizar ();
		SceneManager.LoadScene("Modulo_FimAplicador");

	}
		


	//Update da velocidade do Kim
	public void Update()
	{

		if (isServer) {
			RpcVelocidade (AtivaReplica.velocidade);
		} 

		
	}


	
}

