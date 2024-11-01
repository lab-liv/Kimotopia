using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escolha : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Jogar()
	{
		SceneManager.LoadScene ("Modulo_FaseM");
	}
	public void Dados()
	{
		SceneManager.LoadScene ("Modulo_visualizacao");
	}
	public void Voltar()
	{
		SceneManager.LoadScene ("Modulo_EscolhaAplicador");
	}
}
