using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Linq;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;




public class Fim : MonoBehaviour {

	public string pontos ;

	// Use this for initialization
	void Start () {


		if (GameControllerDesktop.CenaAtual == "Modulo_espera_desktop" || GameControllerDesktop.CenaAtual == "Modulo_espera_acelerometro")
			pontos = GameControllerDesktop.Instance.points.text;
		else {
			pontos = GameController.Instance.points.text;
		}


		//Debug.Log (pontos.ToString());
		GameObject.Find ("pontuacaotxt").GetComponent<Text> ().text = pontos.ToString();

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void Recebe()
	{
		
		SceneManager.LoadScene ("Modulo_fim");
		//GameObject.Find ("pontuacaotxt").GetComponent<Text> ().text = p;

		//GameObject.Find ("pontuacaotxt").GetComponent<Text> ().text = p;

	}
}
