using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Linq;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;

public class Valores_aplicador : MonoBehaviour {

	public string nome;
	public string idade;

	public InputField Nome;
	public InputField Idade;

	public static Valores_aplicador Instance;

	void Start () {

		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		}
		else if (Instance != this)
			Destroy (gameObject);


	}

	public void Click()
	{
		//Debug.Log("entrou4");
		nome = Nome.text;
		idade = Idade.text;
	}
}