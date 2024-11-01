using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;


public class GerarRelatorio : MonoBehaviour {

	public GameObject nomejogador;
	public GameObject idadejogador; 
	public Text txtOk;

	// Use this for initialization
	void Start () {

		txtOk = GameObject.Find ("txtOk").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TaskOnClick3()
	{
		string pasta = Application.persistentDataPath;
		string local = Path.Combine (pasta, "/DadosJogadores.txt");
		StreamWriter sw = new StreamWriter (local, false); //Application.dataPath só salva dados txt no computador

		sw.WriteLine ("Nome do jogador: " ); // + Inputs.nomejogador
		sw.WriteLine ("Idade do jogador: "); // + Inputs.idadejogador
		sw.WriteLine ("Pontuação do jogador: "); // + GameController.pontuacao
		sw.WriteLine ("Data da geração do arquivo: "); // + System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")

		sw.WriteLine ("---------------------------------------------");

		Debug.Log (Application.dataPath); //Mostra o caminho que o arquivo está
		Debug.Log ("Pronto");
		txtOk.text = "OK!";


		sw.Close ();
		Debug.Log ("Close");
	}

}
