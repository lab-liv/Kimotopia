using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class AtivaGameDesktop : MonoBehaviour {

	public static GameObject modulo_game;




	void Awake () {

		//Ativar modulo_game dentro do modulo_aplicador
		modulo_game = GameObject.Find ("Game");
		modulo_game.SetActive (false);
	}


	void Update () {


	}



}
