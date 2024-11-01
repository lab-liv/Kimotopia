using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class CapturaImagem : MonoBehaviour {

	private string _dados;
	public Text txtOk;
	public string nome;

	// Use this for initialization
	void Start () {

		txtOk = GameObject.Find ("txtOk").GetComponent<Text>();

	/*	//_dados = Application.dataPath + "/Imagens/";
		_dados = Application.persistentDataPath+"/Imagens/";
		if (!Directory.Exists (_dados))
		{
			Directory.CreateDirectory (_dados);
		}*/
			
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void TaskOnClickCI()
	{
		nome = GameObject.Find ("txtNome").GetComponent<Text>().text;
		//Debug.Log (Application.persistentDataPath);
			
		//string nomeImagem = _dados + System.DateTime.Now.ToString ("imagem")+".jpg";
		//string nomeImagem2 = _dados + "imagem.jpg";
		//ScreenCapture.CaptureScreenshot (nomeImagem);
		ScreenCapture.CaptureScreenshot (nome+".png");
		//Application.CaptureScreenshot (nomeImagem); 
		txtOk.text = "Salvo como "+nome;

	}

}
