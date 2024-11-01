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

public class Desktop: MonoBehaviour {


	public static GameObject modulo_game;
	public static GameObject modulo_espera;
	public static GameObject modulo_aplicador;

	public void Start()
	{

	}


	//Iniciar
	public void TaskOnClickIniciar()
	{
		AtivaGameDesktop.modulo_game.SetActive(true);
		modulo_espera = GameObject.Find ("Espera");
		modulo_espera.SetActive (false);

	}

	//Finalizar
	public void TaskOnClickFinalizar()
	{

		SceneManager.LoadScene("Modulo_fimDesktop");

	}
	public void TaskOnClickFinalizar2()
	{

		SceneManager.LoadScene("Modulo_FimAcel");

	}



	//Update da velocidade do Kim
	public void Update()
	{

	}



}

