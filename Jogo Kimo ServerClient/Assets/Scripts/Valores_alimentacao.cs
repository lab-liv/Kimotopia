using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Linq;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;

public class Valores_alimentacao : MonoBehaviour {

	// Use this for initialization


	public string tempo_alimentacao;
	public string certos_alimentacao;

	public InputField Tempo2;
	public InputField Certos2;

	public static Valores_alimentacao Instance;

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
		//Debug.Log("entrou2");
		tempo_alimentacao = Tempo2.text;
		certos_alimentacao = Certos2.text;
	}

	// Update is called once per frame
	void Update () {

	}
}
