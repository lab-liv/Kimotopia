using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cadastro : MonoBehaviour {

	public static Text tempo1input;
	public static Text tempo2input;
	public static Text tempo3input;
	public static Text quant1input;
	public static Text quant2input;
	public static Text quant3input;
	public static Button btnIniciar;


	// Use this for initialization
	void Start ()
	{
		tempo1input = GameObject.Find("tempo1input").GetComponent<Text>(); //procura variável do tempo da primeira fase
		tempo2input = GameObject.Find("tempo2input").GetComponent<Text>(); //procura variável da tempo da segunda fase 
		tempo3input = GameObject.Find("tempo3input").GetComponent<Text>(); //procura variável da tempo da terceira fase
		quant1input = GameObject.Find("quant1input").GetComponent<Text>(); //procura variável da quantidade de objetos da primeira fase
		quant2input = GameObject.Find("quant2input").GetComponent<Text>(); //procura variável da quantidade de objetos da segunda fase 
		quant3input = GameObject.Find("quant3input").GetComponent<Text>(); //procura variável da quantidade de objetos da terceira fase

		Button btnIniciar = GameObject.Find("btnIniciar").GetComponent<Button>(); //reconhece o botao iniciar

		//btnIniciar.onClick.AddListener (OnClick);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	//Quando clicado em "iniciar" será guardado o nome e a idade do jogador na variável

	//void OnClick()
	//{
		
	//}

}
