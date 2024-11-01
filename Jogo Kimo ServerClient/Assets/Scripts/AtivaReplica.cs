using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class AtivaReplica : MonoBehaviour {

	public static GameObject modulo_replica;
	public static int velocidade = 0;
	public string vel;
	public static int pontos;
	public static Transform controller;
	public static Vector3 moveVector;

	public  GameObject bom;
	public  GameObject ruim;

	public static int i = 0;
	public static int j = 0;


	public static GameObject obj_bom;
	public static GameObject obj_ruim;

	public static GameObject go_objbom;
	public static GameObject go_objruim;

	public static GameObject[] bons;
	public static GameObject[] ruins;

	public Text points;
	public Text tempo;

	public static Image barImage;

	public static AtivaReplica Instance;

	void Start () {

		points = GameObject.Find ("PontosText").GetComponent<Text> ();
		tempo = GameObject.Find ("timer").GetComponent<Text> ();




		//Ativar modulo_replica dentro do modulo_aplicador
		modulo_replica = GameObject.Find ("Replica");
		modulo_replica.SetActive (false);

		obj_bom = bom;
		obj_ruim = ruim;

		bons = new GameObject[300];
		ruins = new GameObject[300];

		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		}
		else if (Instance != this)
			Destroy (gameObject);
		


	}


	void Update () {

		points = GameObject.Find ("PontosText").GetComponent<Text> ();
	}


	public static void Pontuacao(string p)
	{

		GameObject.Find ("PontosText").GetComponent<Text> ().text = p;
	}

	//ativa objeto_bom

	public static void Objetos(Vector3[] v, int c1)
	{
		//go_objbom.SetActive(false);
		for (i=0; i <= c1; i++) {
			//Debug.Log ("aaaaaaaaaa" + v[i]);
			go_objbom = Instantiate (obj_bom) as GameObject;
			bons[i] = go_objbom;
			go_objbom.SetActive (true);
			go_objbom.transform.parent = GameObject.Find("Objetos").transform;
			Vector3 a = new Vector3 (v[i].x, v[i].y, v[i].z);
			go_objbom.transform.position = a;
		}

	}



	//ativa objeto_ruim
	public static void Objetos2(Vector3[] v2, int c2)
	{
		//go_objruim.SetActive(false);
		for (j=0; j <= c2; j++) {
			//Debug.Log ("aaaaaaaaaaaaaaa" + v2[i]);
			go_objruim = Instantiate (obj_ruim) as GameObject;
			ruins[j] = go_objruim;
			go_objruim.SetActive (true);
			go_objruim.transform.parent = GameObject.Find("Objetos").transform;
			Vector3 b = new Vector3 (v2[j].x, v2[j].y, v2[j].z);
			go_objruim.transform.position = b;
		}

	}

	public static void destruicao()
	{
		for(int i=0;i<300;i++)
		{
			Destroy(ruins[i]);
			Destroy(bons[i]);
		}


	}

	public static void Vida (float v)
	{
		barImage = GameObject.Find ("Status Fill 01").GetComponent<Image> ();
		barImage.fillAmount = v / 10;

	}

	public void MudaVelocidade()
	{
		//Troca de velocidade
		vel = GameObject.Find ("inputvelocidade").GetComponent<InputField> ().text;
		velocidade = int.Parse (vel);
		Debug.Log (vel);
	}


}
