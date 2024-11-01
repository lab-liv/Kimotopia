using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class DadosFinais : MonoBehaviour {

	public Text txtNome;
	public Text txtIdade;
	public Text txtQCM;
	public Text txtQEM;
	public Text txtTempoM;
	public Text txtQCA;
	public Text txtQEA;
	public Text txtTempoA;
	public Text txtQCH;
	public Text txtQEH;
	public Text txtTempoH;
	public Text txtPontos;
   


	// Use this for initialization
	void Start () {

		txtNome = GameObject.Find ("txtNome").GetComponent<Text>();
		txtIdade = GameObject.Find ("txtIdade").GetComponent<Text>();
		txtQCM = GameObject.Find ("txtQCM").GetComponent<Text>();
		txtQEM = GameObject.Find ("txtQEM").GetComponent<Text>();
		txtTempoM = GameObject.Find ("txtTempoM").GetComponent<Text>();
		txtQCA = GameObject.Find ("txtQCA").GetComponent<Text>();
		txtQEA = GameObject.Find ("txtQEA").GetComponent<Text>();
		txtTempoA = GameObject.Find ("txtTempoA").GetComponent<Text>();
		txtQCH = GameObject.Find ("txtQCH").GetComponent<Text>();
		txtQEH = GameObject.Find ("txtQEH").GetComponent<Text>();
		txtTempoH = GameObject.Find ("txtTempoH").GetComponent<Text>();
		txtPontos = GameObject.Find ("txtPontos").GetComponent<Text>();

		//Falta inserir os dados do server, que será buscado por rede 
		txtNome.text = "OK!";  
		txtIdade.text = "OK!";
		txtQCM.text = "OK!";
		txtQEM.text = "OK!";
		txtTempoM.text = "OK!";
		txtQCA.text = "OK!";
		txtQEA.text = "OK!";
		txtTempoA.text = "OK!";
		txtQCH.text = "OK!";
		txtQEH.text = "OK!";
		txtTempoH.text = "OK!";
		txtPontos.text = GameController.pontuacao.ToString();

        

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
