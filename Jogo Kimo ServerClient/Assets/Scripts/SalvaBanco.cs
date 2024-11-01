using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using System.IO;
using System.Data;
using UnityEngine.SceneManagement;

public class SalvaBanco : MonoBehaviour {

	public Text txtNome;
	public Text txtIdade;
	public Text txtPontos;

	string nome = null;
	string idade = null;
	string pontuacao = null;
	string datahora = null;

	string caminho;
	StreamWriter salvar;

	// Use this for initialization
	void Start () {
		txtNome = GameObject.Find ("txtNome").GetComponent<Text> ();
		txtIdade = GameObject.Find ("txtIdade").GetComponent<Text> ();
		txtPontos = GameObject.Find ("txtPontos").GetComponent<Text> ();

		caminho = Application.persistentDataPath + "/dados.csv";
		salvar = new StreamWriter (caminho, true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SalvaDados ()
	{
		nome = txtNome.text;
		idade = txtIdade.text;
		pontuacao = txtPontos.text;
		//datahora = System.DateTime.Now.ToString ("dd/MM/yyyy HH:mm:ss");

		salvar.WriteLine(nome + "," + idade + "," + pontuacao);
		salvar.Flush ();
		salvar.Close ();

		/*
		ConectaBanco.cn.Open ();
		ConectaBanco.sql.CommandText = "INSERT INTO dados (nome, idade, pontuacao, data_geracao)" +
		"VALUES ('" + nome + "', " + idade + ", " + pontuacao + ", '" + datahora + "')";
		ConectaBanco.exec = ConectaBanco.sql.ExecuteReader ();
		ConectaBanco.cn.Close ();
		*/
	}

}
