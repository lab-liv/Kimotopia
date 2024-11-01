using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Linq;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;

public class Valores_medicacao : MonoBehaviour {

	// Use this for initialization


	public string tempo_medicacao;
	public string certos_medicacao;
	public string errados_medicacao;

	public InputField Tempo1;
	public InputField Certos1;
	public InputField Errados1;

	public static Valores_medicacao Instance;

	void Start () {
		


		/*Tempo1 = GameObject.Find ("tempo1input").GetComponent<InputField> ();
		Certos1 = GameObject.Find ("inputQC").GetComponent<InputField> ();
		Errados1 = GameObject.Find ("inputQE").GetComponent<InputField> ();*/

		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		}
		else if (Instance != this)
			Destroy (gameObject);


	}

	public void Click()
	{
		//Debug.Log("entrou");
		tempo_medicacao = Tempo1.text;
		certos_medicacao = Certos1.text;
		errados_medicacao = Errados1.text;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
