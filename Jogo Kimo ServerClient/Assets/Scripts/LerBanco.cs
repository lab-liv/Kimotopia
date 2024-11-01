using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using System.IO;
using System.Data;

public class LerBanco : MonoBehaviour {

    public InputField txtMostra;
    public InputField txtNome;
    public InputField txtIdade;

	string caminho;
	string ler;

	// Use this for initialization
	void Start () {
        txtMostra = GameObject.Find("txtMostra").GetComponent<InputField>();
        txtNome = GameObject.Find("txtNome").GetComponent<InputField>();
        txtIdade = GameObject.Find("txtIdade").GetComponent<InputField>();

		caminho = Application.persistentDataPath + "/dados.csv";
		Debug.Log (caminho);

		if (!File.Exists (caminho)) {
			txtMostra.text = "Nenhum jogador cadastrado...";
		} else {
			ler = File.ReadAllText (caminho);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!File.Exists (caminho)) 
		{} 
		else 
		{
			txtMostra.text = "";

			if (txtNome.text == "" && txtIdade.text == "") 
			{
				string[] linhas = ler.Split ("\n" [0]);
				for (var i = 0; i < linhas.Length; i++) {
					string[] partes = linhas [i].Split ("," [0]);

					txtMostra.text += "Nome: " + partes [0] + " Idade: " + partes [1] + " Pontuacao: " + partes [2] + "\n";
				}
			} 
			else if (txtNome.text != "" && txtIdade.text == "") 
			{
				string[] linhas = ler.Split ("\n" [0]);
				for (var i = 0; i < linhas.Length; i++) {
					string[] partes = linhas [i].Split ("," [0]);

					if (partes[0].ToLower().StartsWith(txtNome.text.ToLower())) 
					{
						txtMostra.text += "Nome: " + partes [0] + " Idade: " + partes [1] + " Pontuacao: " + partes [2] + "\n";
					}
				}
			} 
			else if (txtNome.text == "" && txtIdade.text != "") 
			{
				string[] linhas = ler.Split ("\n" [0]);
				for (var i = 0; i < linhas.Length; i++) {
					string[] partes = linhas [i].Split ("," [0]);

					if (partes [1] == txtIdade.text) 
					{
						txtMostra.text += "Nome: " + partes [0] + " Idade: " + partes [1] + " Pontuacao: " + partes [2] + "\n";
					}
				}
			}
			else if(txtNome.text != "" && txtIdade.text != "")
			{
				string[] linhas = ler.Split ("\n" [0]);
				for (var i = 0; i < linhas.Length; i++) {
					string[] partes = linhas [i].Split ("," [0]);

					if (partes[0].ToLower().StartsWith(txtNome.text.ToLower()) && partes [1] == txtIdade.text) 
					{
						txtMostra.text += "Nome: " + partes [0] + " Idade: " + partes [1] + " Pontuacao: " + partes [2] + "\n";
					}
				}
			}
		}
	}
}
