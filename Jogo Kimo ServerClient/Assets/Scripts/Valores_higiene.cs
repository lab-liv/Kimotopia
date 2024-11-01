using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Linq;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;

public class Valores_higiene : MonoBehaviour {

	public string tempo_higiene;
	public string certos_higiene;

	public InputField Tempo3;
	public InputField Certos3;

	public static Valores_higiene Instance;

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
		//Debug.Log("entrou3");
		tempo_higiene = Tempo3.text;
		certos_higiene = Certos3.text;
	}
		

}
